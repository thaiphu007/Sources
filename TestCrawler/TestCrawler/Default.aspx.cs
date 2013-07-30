using System;
using System.Collections;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace TestCrawler
{
    public partial class Default : Page
    {
        // unique Uri's queue
        private  Queue queueURLS;
        // thread that take the browse editor text to parse it
        private Thread threadParse;
        // binary tree to keep unique Uri's
        private  SortTree urlStorage;
      
        protected void Page_Load(object sender, EventArgs e)
        {
            urlStorage = new SortTree();
            threadsRun = new Thread[1000];
            queueURLS = new Queue();
            InitValues();
        }
       
        void InitValues()
        {
            WebDepth =  3;
            RequestTimeout = 20;
            SleepFetchTime = 2;
            SleepConnectTime = 1;
            KeepSameServer =  false;
            AllMIMETypes =  true;
            KeepAlive = true;
            ExcludeHosts = (".org; .gov;").Replace("*", "").ToLower().Split(';');
            ExcludeFiles =new string[]{};
            Downloadfolder = Server.MapPath("~/Downloads/");
            MIMETypes = GetMIMETypes();
           
        }
       
        void StartParsing()
        {
            btnGo.Enabled = false;
            // insert combo text in the combo list
           
            if (threadParse == null || threadParse.ThreadState != ThreadState.Suspended)
            {
                urlStorage.Clear();
                // start parsing thread
                threadParse = new Thread(RunParser);
                threadParse.Start();
            }
            // update running threads
            ThreadCount =  10;
    
        }
        // timeout of sockets send and receive
        private int RequestTimeout { get; set; }

        // the time that each thread sleeps when the refs queue empty
        private int SleepFetchTime { get; set; }

        private int SleepConnectTime { get; set; }

     
        // download folder
        private string Downloadfolder { get; set; }

        // number of files downloaded
        private int FileCount { get; set; }

        // threads array
        private  Thread[] threadsRun;
        private int nThreadCount;
        private int ThreadCount
        {
            get
            {
                return nThreadCount;
            }
            set
            {
                for (int i = 0; i < value; i++)
                {
                    if ((threadsRun[i] == null) || (threadsRun[i].ThreadState != ThreadState.Suspended))
                    {
                        threadsRun[i] = new Thread(ThreadRunFunction) {Name = i.ToString()};
                        threadsRun[i].Start();
                    }
                    else if (threadsRun[i].ThreadState == ThreadState.Suspended)
#pragma warning disable 612,618
                        threadsRun[i].Resume();
#pragma warning restore 612,618

                }
                nThreadCount = value;
            }
        }
        private void ThreadRunFunction()
        {
            MyWebRequest request = null;
            while (ThreadsRunning && Thread.CurrentThread.Name!=null&& (int.Parse(Thread.CurrentThread.Name) < ThreadCount))
            {
                MyUri uri = DequeueUri();
                if (uri != null)
                {
                    if (SleepConnectTime > 0)
                        Thread.Sleep(SleepConnectTime*2000);
                    ParseUri(uri, ref request);
                }
                else
                    Thread.Sleep(SleepFetchTime * 2000);
            }
           
        }
        // List of a user defined list of restricted hosts extensions to avoid blocking by these hosts
        private string[] ExcludeHosts { get; set; }

        // represents the depth of navigation in the crawling process
        private int WebDepth { get; set; }

        // MIME types are the types that are supported to be downloaded by the crawler 
        // and the crawler includes a default types to be used. 
        private bool AllMIMETypes { get; set; }

        // to limit crawling process to the same host of the original URL
        private bool KeepSameServer { get; set; }

        // means keep socket connection opened for subsequent requests to avoid reconnect time
        private bool KeepAlive { get; set; }
        private string GetMIMETypes()
        {
            string str = "";
            // check for settings xml file existence
            if (File.Exists(Server.MapPath("~/Settings.xml")))
            {
                var doc = new XmlDocument();
                doc.Load(Server.MapPath("~/Settings.xml"));
                if (doc.DocumentElement != null)
                {
                    XmlNode element = doc.DocumentElement.SelectSingleNode("SettingsForm-listViewFileMatches");
                    if (element != null)
                    {
                        for (int n = 0; n < element.ChildNodes.Count; n++)
                        {
                            XmlNode xmlnode = element.ChildNodes[n];
                            if (xmlnode.Attributes != null)
                            {
                                XmlAttribute attribute = xmlnode.Attributes["Checked"];
                                if (attribute == null || attribute.Value.ToLower() != "true")
                                    continue;
                            }
                            string[] items = xmlnode.InnerText.Split('\t');
                            if (items.Length > 1)
                            {
                                str += items[0];
                                if (items.Length > 2)
                                    str += '[' + items[1] + ',' + items[2] + ']';
                                str += ';';
                            }
                        }
                    }
                }
            }
            return str;
        }
        private string MIMETypes
        {
            get; set; }

        private string[] ExcludeFiles { get; set; }

        bool ThreadsRunning;

        void RunParser()
        {
            ThreadsRunning = true;
            
            string strUri = txtUrl.Text;
               
            if (Directory.Exists(strUri))
                ParseFolder(strUri, 0);
            else
            {
                if (File.Exists(strUri) == false)
                {
                    Normalize(ref strUri);
                    txtUrl.Text = strUri;
                }
                var uri = new MyUri(strUri);
                EnqueueUri(uri, false);
            }
            
           
        }

        void ParseFolder(string folderName, int nDepth)
        {
            var dir = new DirectoryInfo(folderName);
            FileInfo[] fia = dir.GetFiles("*.txt");
            foreach (FileInfo f in fia)
            {
                if (ThreadsRunning == false)
                    break;
                var uri = new MyUri(f.FullName) {Depth = nDepth};
                EnqueueUri(uri, true);
            }

            DirectoryInfo[] dia = dir.GetDirectories();
            foreach (DirectoryInfo d in dia)
            {
                if (ThreadsRunning == false)
                    break;
                ParseFolder(d.FullName, nDepth + 1);
            }
        }
        // push uri to the queue
        bool EnqueueUri(MyUri uri, bool bCheckRepetition)
        {
            // add the uri to the binary tree to check if it is duplicated or not
            if (bCheckRepetition && AddURL(ref uri) == false)
                return false;

            Monitor.Enter(queueURLS);
            try
            {
                // add the uri to the queue
                queueURLS.Enqueue(uri);
            }
            catch (Exception)
            {
            }
            Monitor.Exit(queueURLS);

            return true;
        }

        // pop uri from the queue
        MyUri DequeueUri()
        {
            Monitor.Enter(queueURLS);
            MyUri uri = null;
            try
            {
                if (queueURLS.Count > 0)
                    uri = (MyUri)queueURLS.Dequeue();
            }
            catch (Exception)
            {
            }
            Monitor.Exit(queueURLS);
            return uri;
        }

        private void Normalize(ref string strURL)
        {
            if (strURL.StartsWith("http://") == false)
                strURL = string.Format("http://{0}", strURL);
            if (strURL.IndexOf("/", 8, StringComparison.Ordinal) == -1)
                strURL += '/';
        }

        private bool AddURL(ref MyUri uri)
        {
            foreach (string str in ExcludeHosts)
                if (str.Trim().Length > 0 && uri.Host.ToLower().IndexOf(str.Trim(), StringComparison.Ordinal) != -1)
                    return false;
         
            bool bNew = false;
            try
            {
                string strURL = uri.AbsoluteUri;
                bNew = urlStorage.Add(ref strURL).Count == 1;
            }
            catch (Exception)
            {
            }
       
            return bNew;
        }

        // pause all working threads
        void PauseParsing()
        {
            if(threadParse!=null)
            if (threadParse.ThreadState == ThreadState.Running)
#pragma warning disable 612,618
                threadParse.Suspend();
#pragma warning restore 612,618

            for (int n = 0; n < ThreadCount; n++)
            {
                Thread thread = threadsRun[n];
                if(thread!=null)
                if (thread.ThreadState == ThreadState.Running)
#pragma warning disable 612,618
                    thread.Suspend();
#pragma warning restore 612,618
            }
           
        }

        // abort all working threads
        void StopParsing()
        {
            queueURLS.Clear();
            ThreadsRunning = false;
            Thread.Sleep(500);
            if (threadParse != null)
                if (threadParse.ThreadState == ThreadState.Suspended)
#pragma warning disable 612,618
                    threadParse.Resume();
#pragma warning restore 612,618
            if (threadParse != null)
                threadParse.Abort();
           
        
            for (int n = 0; n < ThreadCount; n++)
            {
              
                    Thread thread = threadsRun[n];
                  
                    if (thread != null && thread.IsAlive)
                    {
                        if (thread.ThreadState == ThreadState.Suspended)
#pragma warning disable 612,618
                            thread.Resume();
#pragma warning restore 612,618
                        thread.Abort();
                    }
            }

            queueURLS.Clear();
            urlStorage.Clear();
        }

        void ParseUri(MyUri uri, ref MyWebRequest request)
        {
            string strStatus = "";
            // check if connection is kept alive from previous connections or not
            if (request != null && request.response.KeepAlive)
                strStatus += "Connection live to: " + uri.Host + "\r\n\r\n";
            else
                strStatus += "Connecting: " + uri.Host + "\r\n\r\n";

            // create web request
            request = MyWebRequest.Create(uri, request, KeepAlive);
            // set request timeout
            request.Timeout = RequestTimeout * 1000;
            // retrieve response from web request
            MyWebResponse response = request.GetResponse();
            // update status text with the request and response headers
            strStatus += request.Header + response.Header;

            // check for redirection
            if (response.ResponseUri.Equals(uri) == false)
            {
                // add the new uri to the queue
                EnqueueUri(new MyUri(response.ResponseUri.AbsoluteUri), true);
                request = null;
                return;
            }

            // check for allowed MIME types
            if (AllMIMETypes == false && response.ContentType != null && MIMETypes.Length > 0)
            {
                string strContentType = response.ContentType.ToLower();
                int nExtIndex = strContentType.IndexOf(';');
                if (nExtIndex != -1)
                    strContentType = strContentType.Substring(0, nExtIndex);
                if (strContentType.IndexOf('*') == -1 &&
                    (nExtIndex = MIMETypes.IndexOf(strContentType, StringComparison.Ordinal)) == -1)
                    return;
                // find numbers
                Match match = new Regex(@"\d+").Match(MIMETypes, nExtIndex);
                int nMin = int.Parse(match.Value) * 1024;
                match = match.NextMatch();
                int nMax = int.Parse(match.Value) * 1024;
                if (nMin < nMax && (response.ContentLength < nMin || response.ContentLength > nMax))
                    return;
            }
            // check for response extention
            string[] ExtArray = { ".gif", ".jpg", ".css", ".zip", ".exe" };
            bool bParse = true;

            foreach (string ext in ExtArray)
                if (uri.AbsoluteUri.ToLower().EndsWith(ext))
                {
                    bParse = false;
                    break;
                }
            foreach (string ext in ExcludeFiles)
                if (ext.Trim().Length > 0 && uri.AbsoluteUri.ToLower().EndsWith(ext))
                {
                    bParse = false;
                    break;
                }

            // construct path in the hard disk
            string strLocalPath = uri.LocalPath;
            // check if the path ends with / to can crate the file on the HD 
            if (strLocalPath.EndsWith("/"))
                if (uri.Query == "")  // check if there is no query like (.asp?i=32&j=212)
                    strLocalPath += "default.html";// add a default name for / ended pathes
            // check if the uri includes a query string
            if (uri.Query != "")
                // construct the name from the query hash value to be the same if we download it again
                strLocalPath += string.Format("{0}.html", uri.Query.GetHashCode()); 
            // construct the full path folder
            string BasePath = string.Format("{0}\\{1}{2}", Downloadfolder, uri.Host, Path.GetDirectoryName(uri.AbsolutePath));
            // check if the folder not found
            if (Directory.Exists(BasePath) == false)// create the folder
            {
                
                try
                {
                    Directory.CreateDirectory(BasePath);
                }
                catch
                {
                    string path = BasePath + (new Random()).Next(0, 99);
                    Directory.CreateDirectory(path);
                }
            }
            // construct the full path name of the file
            string PathName = string.Format("{0}\\{1}{2}", Downloadfolder, uri.Host, strLocalPath.Replace("%20", " "));
            if (PathName.IndexOf(".htm", StringComparison.Ordinal) == -1 && PathName.IndexOf(".html", StringComparison.Ordinal) == -1)
                PathName += ".html";
            // open the output file
            FileStream streamOut = File.Open(PathName, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            var writer = new BinaryWriter(streamOut);
              
            // receive response buffer
            string strResponse = "";
            var RecvBuffer = new byte[10240];
            int nBytes, nTotalBytes = 0;
            // loop to receive response buffer
            while ((nBytes = response.socket.Receive(RecvBuffer, 0, 10240, SocketFlags.None)) > 0)
            {
                // increment total received bytes
                nTotalBytes += nBytes;
                // write received buffer to file
                writer.Write(RecvBuffer, 0, nBytes);
                // check if the uri type not binary to can be parsed for refs
                if (bParse)
                    // add received buffer to response string
                    strResponse += Encoding.ASCII.GetString(RecvBuffer, 0, nBytes);
                // update view text
                
                // check if connection Keep-Alive to can break the loop if response completed
                if (response.KeepAlive && nTotalBytes >= response.ContentLength && response.ContentLength > 0)
                    break;
            }
            // close output stream
            writer.Close();
            streamOut.Close();

            if (response.KeepAlive)
                strStatus += "Connection kept alive to be used in subpages.\r\n";
            else
            {
                // close response
                response.Close();
                strStatus += "Connection closed.\r\n";
            }
            // update status
             
            // increment total file count
            FileCount++;
            // increment total bytes count
             

            if (ThreadsRunning && bParse && uri.Depth < WebDepth)
            {
                strStatus += "\r\nParsing page ...\r\n";
                // parse the page to search for refs
                string strRef = @"(href|HREF|src|SRC)[ ]*=[ ]*[""'][^""'#>]+[""']";
                MatchCollection matches = new Regex(strRef).Matches(strResponse);
                strStatus += "Found: " + matches.Count + " ref(s)\r\n";
                foreach (Match match in matches)
                {
                    strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"', '\'', '#', ' ', '>');
                    try
                    {
                        if (strRef.IndexOf("..", StringComparison.Ordinal) != -1 || strRef.StartsWith("/") || strRef.StartsWith("http://") == false)
                            strRef = new Uri(uri, strRef).AbsoluteUri;
                        Normalize(ref strRef);
                        var newUri = new MyUri(strRef);
                        if (newUri.Scheme != Uri.UriSchemeHttp && newUri.Scheme != Uri.UriSchemeHttps)
                            continue;
                        if (newUri.Host != uri.Host && KeepSameServer)
                            continue;
                        newUri.Depth = uri.Depth + 1;
                        if (EnqueueUri(newUri, true))
                            strStatus += string.Format("{0}\r\n", newUri.AbsoluteUri);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            lblStatus.Text = strStatus;
        }

        private void CreateFolderDownload(string urlDownload)
        {
            urlDownload = urlDownload.Replace("http://", "").Replace("https://", "");
            urlDownload = urlDownload.Substring(0, urlDownload.IndexOf('/') ==-1? urlDownload.Length : urlDownload.IndexOf('/'));
            Downloadfolder = Server.MapPath(string.Format("~/Downloads/{0}", urlDownload));
            if (!Directory.Exists(Downloadfolder))
                Directory.CreateDirectory(Downloadfolder);
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if(button!=null)
                if (button.Equals(btnGo))
                {
                    CreateFolderDownload(txtUrl.Text.Trim());
                    StartParsing();
                }
                else if (button.Equals(btnPause))
                    PauseParsing();
                else if (button.Equals(btnStop))
                    StopParsing();
        }
    }
}