//
//  Bardecode.m
//  iBardecode
//
//  Copyright 2010 Softek Software Ltd. All rights reserved.
//

#import "Bardecode.h"


@implementation Bardecode

- (id) init
{
    if ( self = [super init] )
    {
        //[self setReadCode39:NO];
        [self setReadCode128:NO];
        [self setReadCodabar:NO];
        [self setReadCode25:NO];
        [self setReadCode25ni:NO];
        [self setReadDatabar:NO];
        [self setReadEAN13:NO];
        [self setReadEAN8:NO];
        [self setReadUPCA:NO];
        [self setReadUPCE:NO];
        [self setReadDatamatrix:NO];
		[self setLicenseKey:@""];
		[self setBarcodeValue:@""];
		[self setBarcodeType:@""];
		[self setCancelButton:NULL];
		[self setViewForPreview:NULL];
		[self setWaitForFocus:NO];
		[self setBackgroundImageView:NULL];
		[self setOverlayImageView:NULL];
		[self setBackgroundImage:NULL];
		[self setOverlayImage:NULL];
		[self setTestImage:NULL];
		[self setTestImageView:NULL];
		[self setTestButton:NULL];
		haveReadBarcode = NO;
		haveDonePreviewSetup = NO ;
#if ! TARGET_IPHONE_SIMULATOR
		[self setSession:NULL];
		[self setDevice:NULL];
		[self setPreviewLayer:NULL];
#endif		
    }
    return self;
}

- (void) dealloc
{
#if ! TARGET_IPHONE_SIMULATOR
	[Session autorelease];
	[Device autorelease];
	[PreviewLayer autorelease];
#endif
	[ViewForPreview autorelease];
	[BackgroundImageView autorelease];
	[OverlayImageView autorelease];
	[BackgroundImage autorelease];
	[OverlayImage autorelease];
	[CancelButton autorelease];
	[BarcodeValue autorelease];
	[BarcodeType autorelease];
	[LicenseKey autorelease];
	[TestImageView autorelease];
	[TestImage autorelease];
	[TestButton autorelease];
	[super dealloc];
	
}
   
- (void) setWaitForFocus: (bool)input
{
    WaitForFocus = input ;
}

#if ! TARGET_IPHONE_SIMULATOR
- (void) setSession: (AVCaptureSession *) input{
    [Session autorelease];
	Session = [input retain] ;
}

- (void) setDevice: (AVCaptureDevice *) input{
    [Device autorelease];
	Device = [input retain] ;
}

- (void) setPreviewLayer: (AVCaptureVideoPreviewLayer *) input{
    [PreviewLayer autorelease];
	PreviewLayer = [input retain] ;
}
#endif

- (void) setViewForPreview: (UIView *) input{
	[ViewForPreview autorelease];
	ViewForPreview = [input retain] ;
}

- (void) setBackgroundImageView: (UIImageView *) input{
	[BackgroundImageView autorelease];
	BackgroundImageView = [input retain] ;
}

- (void) setOverlayImageView: (UIImageView *) input{
	[OverlayImageView autorelease];
	OverlayImageView = [input retain] ;
}

- (void) setTestImageView: (UIImageView *) input{
	[TestImageView autorelease];
	TestImageView = [input retain] ;
}

- (void) setBackgroundImage: (UIImage *) input{
	[BackgroundImage autorelease];
	BackgroundImage = [input retain] ;
}

- (void) setOverlayImage: (UIImage *) input{
	[OverlayImage autorelease];
	OverlayImage = [input retain] ;
}

- (void) setTestImage: (UIImage *) input{
	[TestImage autorelease];
	TestImage = [input retain] ;
}

- (void) setCancelButton: (UIButton *) input{
    [CancelButton autorelease];
	CancelButton = [input retain] ;
}

- (void) setTestButton: (UIButton *) input{
    [TestButton autorelease];
	TestButton = [input retain] ;
}

- (NSString*) BarcodeValue {
    return BarcodeValue;
}

- (void) setBarcodeValue: (NSString *) input
{
	[BarcodeValue autorelease] ;
	BarcodeValue = [input retain] ;
}

- (NSString*) BarcodeType {
    return BarcodeType;
}

- (void) setBarcodeType: (NSString *) input
{
	[BarcodeType autorelease] ;
	BarcodeType = [input retain] ;
}

- (UIViewController*) Delegate {
	return Delegate;
}

- (void) setDelegate: (UIViewController *)input
{
	Delegate = input ;
}

- (void) setLicenseKey: (NSString *) input
{
	[LicenseKey autorelease] ;
	LicenseKey = [input retain] ;
}

- (void) setReadCode39: (bool)input
{
    ReadCode39 = input ;
}

- (void) setReadCode128: (bool)input
{
    ReadCode128 = input ;
}

- (void) setReadCodabar: (bool)input
{
    ReadCodabar = input ;
}

- (void) setReadDatabar: (bool)input
{
    ReadDatabar = input ;
}

- (void) setReadDatamatrix: (bool)input
{
    ReadDatamatrix = input ;
}

- (void) setReadEAN8: (bool)input
{
    ReadEAN8 = input ;
}

- (void) setReadEAN13: (bool)input
{
    ReadEAN13 = input ;
}

- (void) setReadUPCA: (bool)input
{
    ReadUPCA = input ;
}

- (void) setReadUPCE: (bool)input
{
    ReadUPCE = input ;
}

- (void) setReadCode25: (bool)input
{
    ReadCode25 = input ;
}

- (void) setReadCode25ni: (bool)input
{
    ReadCode25ni = input ;
}

// Function that actually scans an image for a barcode.
-(int)ScanBarcodeFromBitmap:(CGImageRef)inImage
{
	void *hBarcode ;
	int n ;
	BITMAP bm ;
	char **bar_codes ;
	char **bar_codes_type ;
	
	hBarcode = STCreateBarCodeSession() ;
	
	// Create the BITMAP structure from the CGImageRef
	bm.bmType = 0 ;
	bm.bmWidth = CGImageGetWidth(inImage) ; /* Pixel width */
	bm.bmHeight = CGImageGetHeight(inImage) ; /* Pixel height */
	bm.bmWidthBytes = CGImageGetBytesPerRow(inImage) ;
	bm.bmBitsPixel = CGImageGetBitsPerPixel(inImage) ;
	bm.bmPlanes = 1 ;
	//bm.bmBits = bits ;
	CFDataRef pixels = CGDataProviderCopyData(CGImageGetDataProvider(inImage));
	long dataLength = CFDataGetLength(pixels);	
	uint8_t* picture_buff = (uint8_t*)malloc(dataLength);
	CFDataGetBytes(pixels, CFRangeMake(0, dataLength), picture_buff);
	bm.bmBits = (void *) picture_buff ;	
	
	// Set some parameters to control the barcode reading.
	
	// Color processing level can range from 0 (fastest) to 5 (slowest)
	uint16 val = 2 ;
	STSetParameter(hBarcode, ST_COLOR_PROCESSING_LEVEL, &val) ; 
	
	// Show check digits
	val = 1 ;
	STSetParameter(hBarcode, ST_SHOW_CHECK_DIGIT, &val) ;
	
	// Enable/Disable some barcode types
	
	// Interleaved Code 2 of 5
	val = ReadCode25 ;
	STSetParameter(hBarcode, ST_READ_CODE25, &val) ;
	
	// Other types of Code 25 (IATA, Matrix, Industrial etc)
	val = ReadCode25ni ;
	STSetParameter(hBarcode, ST_READ_CODE25_NI, &val) ;
	
	// Code 3 of 9
	val = ReadCode39 ;
	STSetParameter(hBarcode, ST_READ_CODE39, &val) ;
	
	// Code 128
	val = ReadCode128 ;
	STSetParameter(hBarcode, ST_READ_CODE128, &val) ;
	
	// EAN-13 
	val = ReadEAN13 ;
	STSetParameter(hBarcode, ST_READ_EAN13, &val) ;
	
	// UPC-A (which is a sub-type of EAN-13)
	// Turn off EAN-13 if you only want to see UPC-A barcodes.
	val = ReadUPCA ;
	STSetParameter(hBarcode, ST_READ_UPCA, &val) ;
	
	// EAN-8
	val = ReadEAN8 ;
	STSetParameter(hBarcode, ST_READ_EAN8, &val) ;
	
	// UPC-E
	val = ReadUPCE ;
	STSetParameter(hBarcode, ST_READ_UPCE, &val) ;
	
	// Codabar
	val = ReadCodabar ;
	STSetParameter(hBarcode, ST_READ_CODABAR, &val) ;
	
	// Datamatrix
	val = ReadDatamatrix ;
	STSetParameter(hBarcode, ST_READ_DATAMATRIX, &val) ;
	
	// Databar
	val = ReadDatabar ;
	STSetParameter(hBarcode, ST_READ_DATABAR, &val) ;
	
	// Use one color chunk per 100 pixels
	val = bm.bmWidth / 100 ;
	if (val > 8)
		val = 8 ;
	STSetParameter(hBarcode, ST_COLOR_CHUNKS, &val) ;
	
	// Set MinOccurrence and PrefOccurrence to 10 to reduce false positive results
	//val = 10 ;
	//STSetParameter(hBarcode, ST_MIN_OCCURRENCE, &val) ;
	//STSetParameter(hBarcode, ST_PREF_OCCURRENCE, &val) ;
	
	// Set quiet zone size to around 5 pixels for a screen image and proportionally more for a higher res image
	val = bm.bmWidth / 64 ;
	STSetParameter(hBarcode, ST_QUIET_SIZE, &val) ;
	
	val = 15 ;
	STSetParameter(hBarcode, ST_ORIENTATION_MASK, &val) ;
	
	// A 30 day license can be obtained from sales@bardecode.com
	char *license = (char *) [LicenseKey cStringUsingEncoding:[NSString defaultCStringEncoding]] ;
	STSetParameter(hBarcode, ST_LICENSE, license) ;
	
	// Read the barcode from the image.
	
	n = STReadBarCodeFromBitmap(hBarcode, &bm, (float) 200, &bar_codes, &bar_codes_type, 0) ;
	
	// Create the string to pass back
	if (n)
	{
		[self setBarcodeValue:[NSString stringWithFormat:@"%s",bar_codes[0]]];
		[self setBarcodeType:[NSString stringWithFormat:@"%s",bar_codes_type[0]]];
	}
	
	STFreeBarCodeSession(hBarcode);

	free(picture_buff) ;
	
	CFRelease(pixels);
	
	return n ;
}

// Set the barcode value and type to ""
-(void) emptyResults
{
	[self setBarcodeValue:@""] ;
	[self setBarcodeType:@""] ;
}

// Get the UIView to layer the video preview on top of.
-(UIView *) getViewForPreview
{
	if (ViewForPreview)
		return ViewForPreview ;
	else
		return [self Delegate].view ;
}

// Set up the capture session.
- (void)setupCaptureSession 
{
	haveReadBarcode = FALSE ;
	
#if TARGET_IPHONE_SIMULATOR
	if (haveDonePreviewSetup)
	{
		[self ResizePreview];
		[self addViews];
	}
	else 
	{
		[self setupPreview] ;
	}
#else	
    NSError *error = nil;
	
	AVCaptureSession *session = Session ;
	
	if (haveDonePreviewSetup)
	{
		[self ResizePreview];
		[self addViews];
		[session startRunning] ;
		return ;
	}
	
    // Create the session
    session = [[AVCaptureSession alloc] init];
	
		
    // Configure the session to produce lower resolution video frames, if your 
    // processing algorithm can cope. We'll specify medium quality for the
    // chosen device.
    session.sessionPreset = AVCaptureSessionPresetMedium;
	
	
    // Find a suitable AVCaptureDevice
    AVCaptureDevice *device = [AVCaptureDevice
							   defaultDeviceWithMediaType:AVMediaTypeVideo];
	
    // Create a device input with the device and add it to the session.
    AVCaptureDeviceInput *input = [AVCaptureDeviceInput deviceInputWithDevice:device 
																		error:&error];
    if (!input) {
        // Handling the error appropriately.
		[self sendNotification:@"UserDidCancel"];	
		return ;
    }
    [session addInput:input];

	// Assign session to an ivar.
	
	[self setSession:session];
	[self setDevice:device];
	
	// Start the preview screen
	[self setupPreview];
	
    // Create a VideoDataOutput and add it to the session
    AVCaptureVideoDataOutput *output = [[[AVCaptureVideoDataOutput alloc] init] autorelease];
    [session addOutput:output];
	
    // Configure the output.
    dispatch_queue_t queue = dispatch_queue_create("myQueue", NULL);
    [output setSampleBufferDelegate:self queue:queue];
    dispatch_release(queue);
	
    // Specify the pixel format
    output.videoSettings = 
	[NSDictionary dictionaryWithObject:
	 [NSNumber numberWithInt:kCVPixelFormatType_32BGRA] 
								forKey:(id)kCVPixelBufferPixelFormatTypeKey];
	
	
    // We use 10 fps for barcode reading.
    output.minFrameDuration = CMTimeMake(1, 10);

	
    // Start the session running to start the flow of data
    [session startRunning];
#endif
}

// Set up the video preview
// The images are not mandatory but do improve the appearance of the screen during the capture process.
// The test image is useful when using the simulator to test the successful read of a barcode.
-(void) setupPreview
{
	haveDonePreviewSetup = YES ;
	
	[self setBackgroundImage:[UIImage imageNamed:@"video_preview_bg.png"]];
	if (BackgroundImage)
		[self setBackgroundImageView:[[UIImageView alloc] initWithImage:BackgroundImage]];
	
	[self setOverlayImage:[UIImage imageNamed:@"video_preview_ov.png"]];
	if (OverlayImage)
		[self setOverlayImageView:[[UIImageView alloc] initWithImage:OverlayImage]];
	
#if TARGET_IPHONE_SIMULATOR
	[self setTestImage:[UIImage imageNamed:@"video_preview_simulator_test.png"]];
	if (TestImage)
		[self setTestImageView:[[UIImageView alloc] initWithImage:TestImage]];
#else
	// Create the video capture preview
	[self setPreviewLayer:[AVCaptureVideoPreviewLayer layerWithSession:Session]];
#endif
	
	// Create the cancel button and add it's target
	UIButton *cancelButton = [UIButton buttonWithType:UIButtonTypeRoundedRect];
	cancelButton.frame = CGRectMake(10, 10, 70, 30); // position in the parent view and set the size of the button
	[cancelButton setTitle:@"Cancel" forState:UIControlStateNormal];
		
	[cancelButton addTarget:self action:@selector(cancelButtonClicked:) forControlEvents:UIControlEventTouchUpInside];
	[self setCancelButton:cancelButton] ;

#if TARGET_IPHONE_SIMULATOR
	// Create the test button and add it's target
	UIButton *testButton = [UIButton buttonWithType:UIButtonTypeRoundedRect];
	testButton.frame = CGRectMake(90, 10, 70, 30); // position in the parent view and set the size of the button
	[testButton setTitle:@"Test" forState:UIControlStateNormal];
	
	[testButton addTarget:self action:@selector(testButtonClicked:) forControlEvents:UIControlEventTouchUpInside];
	[self setTestButton:testButton] ;
#endif	
	
	[self ResizePreview] ;
	[self addViews];
	[self showIdleState] ;
}

// Set the orientation and size of the video preview frame and the background and overlay images
// The orientation should always be the same as the view controller.
// The background and overlay images are always rotated back to their upright/portrait orientation so that they appear static on the screen.
-(void) ResizePreview
{
#if ! TARGET_IPHONE_SIMULATOR
	if (PreviewLayer == NULL)
		return ;
#endif
	
	
	UIViewController *viewController = [self getViewController] ;
	
	UIInterfaceOrientation orientation ;
	
	if (viewController)
		orientation = viewController.interfaceOrientation ;
	else
		orientation = UIInterfaceOrientationPortrait ;
	
#if TARGET_IPHONE_SIMULATOR
	if (TestImageView)
		[self restoreImageView:TestImageView Orientation:UIInterfaceOrientationPortrait] ;
#else
	UIView *aView = [self getViewForPreview] ;
	PreviewLayer.frame = aView.bounds;
	PreviewLayer.orientation = orientation ;
#endif
	
	if (BackgroundImageView)
		[self restoreImageView:BackgroundImageView Orientation:orientation] ;
	
	if (OverlayImageView)
		[self restoreImageView:OverlayImageView Orientation:orientation] ;
	
}

// Get the view controller for the preview view.
- (UIViewController*)getViewController {
	UIView *aView = [self getViewForPreview] ;
	for (UIView* next = aView; next; next = next.superview) {
		UIResponder* nextResponder = [next nextResponder];
		if ([nextResponder isKindOfClass:[UIViewController class]]) {
			return (UIViewController*)nextResponder;
		}
	}
	return nil;
}

// Restore an image back to it's upright/portrait orientation.
- (void)	restoreImageView: (UIImageView *) view
			Orientation: (UIInterfaceOrientation) orientation
{
	int d ;
	float x, y, s, w, h ;
	CGSize sz ;
	
	
	x = y = 0 ;
	s = 1 ;
	
	UIView *aView = [self getViewForPreview] ;
	d = abs(aView.bounds.size.height - aView.bounds.size.width);
	d /= 2 ;
	
	CGAffineTransform t ;
	
	w = aView.bounds.size.width ;
	h = aView.bounds.size.height ;

	if (orientation == UIInterfaceOrientationLandscapeLeft)
	{
		t = CGAffineTransformMakeRotation(M_PI/2) ;
		x = d ;
		y = -d ;
		sz.width = h ;
		sz.height = w ;
	}
	else if (orientation == UIInterfaceOrientationPortraitUpsideDown)
	{
		t = CGAffineTransformMakeRotation(M_PI) ;
		sz.width = w ;
		sz.height = h ;
	}	
	else if (orientation == UIInterfaceOrientationLandscapeRight)
	{
		t = CGAffineTransformMakeRotation(- M_PI/2) ;
		x = d ;
		y = -d ;
		sz.width = h ;
		sz.height = w ;
	}
	else
	{
		t = CGAffineTransformMakeRotation(0);
		sz.width = w ;
		sz.height = h ;
	}

	view.transform = t ;
	
	CGRect b ;
	b.origin = CGPointMake(x,y);
	b.size = sz ;
	view.frame = b ;
	view.bounds = b ;
	
	
}

// Remove the cancel button, overlay image, video preview and background image from the super view.
- (void) removeViews
{
#if TARGET_IPHONE_SIMULATOR
	[TestButton removeFromSuperview];
#endif
	[CancelButton removeFromSuperview];
	if (OverlayImageView)
		[OverlayImageView removeFromSuperview];
#if TARGET_IPHONE_SIMULATOR
	if (TestImageView)
		[TestImageView removeFromSuperview];
#else
	[PreviewLayer removeFromSuperlayer];
#endif
	if (BackgroundImageView)
		[BackgroundImageView removeFromSuperview];
}

// Add the background image, video preview, overlay image and cancel button on top of the super view.
- (void) addViews
{
	UIView *aView = [self getViewForPreview] ;
	if (BackgroundImageView)
		[aView addSubview:BackgroundImageView];
#if TARGET_IPHONE_SIMULATOR
	if (TestImageView)
		[aView addSubview:TestImageView];
#else
	[aView.layer addSublayer:PreviewLayer];
#endif
	if (OverlayImageView)
		[aView addSubview:OverlayImageView];
	[aView addSubview:CancelButton];
#if TARGET_IPHONE_SIMULATOR
		[aView addSubview:TestButton];
#endif
}

// Called to stop the capture session and remove the video preview from the super view.
-(void) cleanUpVideoCapture 
{
	[self removeViews];
#if ! TARGET_IPHONE_SIMULATOR
	[Session stopRunning] ;
#endif
}

// Called when a barcode has been read.
-(void) captureSuccess
{
	haveReadBarcode = TRUE ;
	[self showIdleState] ;
	[self cleanUpVideoCapture] ;
	[self sendNotification:@"BarcodeDidRead"];
}

// Displays something to show that the sdk is busy scanning for barcodes - in this case the text on the cancel button is set to blue
- (void) showBusyState
{
	[CancelButton setTitleColor:[UIColor blueColor] forState:UIControlStateNormal];
}

// Displays something to show that the sdk is currently not scanning for barcodes - in this case the text on the cancel button is set to black
- (void) showIdleState
{
	[CancelButton setTitleColor:[UIColor blackColor] forState:UIControlStateNormal];
}

// Called when the Cancel button is tapped.
-(IBAction) cancelButtonClicked:(id) sender {
	[self cleanUpVideoCapture] ;
	[self sendNotification:@"UserDidCancel"];	
}

// Called when the Test button is tapped.
-(IBAction) testButtonClicked:(id) sender {
	if (! TestImageView)
		return ;
	
	if ([self ScanBarcodeFromBitmap:TestImage.CGImage] > 0)
		[self captureSuccess] ;
}


#if ! TARGET_IPHONE_SIMULATOR
// Delegate routine that is called when a sample buffer was written
- (void)captureOutput:(AVCaptureOutput *)captureOutput 
didOutputSampleBuffer:(CMSampleBufferRef)sampleBuffer 
	   fromConnection:(AVCaptureConnection *)connection
{ 
	if (haveReadBarcode || (Device.adjustingFocus && WaitForFocus))
	{
		[self performSelectorOnMainThread:@selector(showIdleState) withObject:nil waitUntilDone:false];
		return ;
	}
	
	[self performSelectorOnMainThread:@selector(showBusyState) withObject:nil waitUntilDone:false];
	
    // Create a UIImage from the sample buffer data
	CGImageRef image = [self imageFromSampleBuffer:sampleBuffer];
	
	// Test for barcode
	int n = [self ScanBarcodeFromBitmap:image] ;
	CGImageRelease(image) ;

	if (n > 0)
	{
		// React if barcode found
		[self performSelectorOnMainThread:@selector(captureSuccess) withObject:nil waitUntilDone:false];
	}
}
#endif

// Create a CGImageRef from sample buffer data
- (CGImageRef) imageFromSampleBuffer:(CMSampleBufferRef) sampleBuffer 
{
    CVImageBufferRef imageBuffer = CMSampleBufferGetImageBuffer(sampleBuffer);
    // Lock the base address of the pixel buffer
    CVPixelBufferLockBaseAddress(imageBuffer,0);
	
    // Get the number of bytes per row for the pixel buffer
    size_t bytesPerRow = CVPixelBufferGetBytesPerRow(imageBuffer); 
    // Get the pixel buffer width and height
    size_t width = CVPixelBufferGetWidth(imageBuffer); 
    size_t height = CVPixelBufferGetHeight(imageBuffer); 
	
    // Create a device-dependent RGB color space
    CGColorSpaceRef colorSpace = CGColorSpaceCreateDeviceRGB(); 
    if (!colorSpace) 
    {
        NSLog(@"CGColorSpaceCreateDeviceRGB failure");
        return nil;
    }
	
    // Get the base address of the pixel buffer
    void *baseAddress = CVPixelBufferGetBaseAddress(imageBuffer);
    // Get the data size for contiguous planes of the pixel buffer.
    size_t bufferSize = CVPixelBufferGetDataSize(imageBuffer); 
	
    // Create a Quartz direct-access data provider that uses data we supply
    CGDataProviderRef provider = CGDataProviderCreateWithData(NULL, baseAddress, bufferSize, 
															  NULL);
    // Create a bitmap image from data supplied by our data provider
    CGImageRef cgImage = 
	CGImageCreate(width,
				  height,
				  8,
				  32,
				  bytesPerRow,
				  colorSpace,
				  kCGImageAlphaNoneSkipFirst | kCGBitmapByteOrder32Little,
				  provider,
				  NULL,
				  true,
				  kCGRenderingIntentDefault);
    CGDataProviderRelease(provider);
    CGColorSpaceRelease(colorSpace);
	
    CVPixelBufferUnlockBaseAddress(imageBuffer, 0);
	
    return cgImage;
}


-(void) ScanBarcodeFromCameraRoll
{
	[self emptyResults];
	scanTimer = nil ;
	
	picker = [[UIImagePickerController alloc] init];

	picker.delegate = self;
	
	picker.sourceType = UIImagePickerControllerSourceTypeSavedPhotosAlbum;

	[Delegate presentModalViewController:picker animated:YES];
	
}


-(void) ScanBarcodeFromViewFinder
{
	[self setupCaptureSession] ;
}

-(void) ScanBarcodeFromCamera
{
	[self emptyResults];
	scanTimer = nil;
#if ! TARGET_IPHONE_SIMULATOR
	[self setSession:NULL];
#endif
	
	picker = [[UIImagePickerController alloc] init];
	
	picker.delegate = self;
	
	picker.sourceType = UIImagePickerControllerSourceTypeCamera;
	
	[Delegate presentModalViewController:picker animated:YES];
}

-(void) sendNotification: (NSString *)name
{
	if ([[self Delegate] respondsToSelector:@selector(BardecodeDidFinish:)]) {
		[[self Delegate] BardecodeDidFinish:[NSNotification notificationWithName:name object:self]];
		return ;
	}		
}

- (void)imagePickerController:(UIImagePickerController *) pkr didFinishPickingMediaWithInfo:(NSDictionary *)info {
	[pkr dismissModalViewControllerAnimated:YES];
	
	CGImageRef image = [(UIImage*) [info objectForKey:@"UIImagePickerControllerOriginalImage"] CGImage] ;

	int n = [self ScanBarcodeFromBitmap:image] ;
	
	if (n > 0)
		[self sendNotification:@"BarcodeDidRead"] ;
	else {
		[self sendNotification:@"BarcodeDidNotRead"] ;
	}	
	
}

- (void) imagePickerControllerDidCancel:(UIImagePickerController *) pkr
{
	[pkr dismissModalViewControllerAnimated:YES];
	[self sendNotification:@"UserDidCancel"] ;
}

@end
