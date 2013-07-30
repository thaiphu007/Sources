Softek Barcode Reader Toolkit for the iPhone

Version 7.3.1g September 2010

The simplest way to understand how to use the toolkit is through the sample XCode projects called iBardecode_ios3 and iBardecode_ios4. 

Please note that there is one version of the project for IOS 3 and another for IOS 4. If you wish to submit your app to the iTunes store then DO NOT BASE YOUR APP ON THE IOS 3 SAMPLE PROJECT BECAUSE IT WILL BE REJECTED BY ITUNES. Since mid-July 2010 Apple will only accept code based on the IOS 4 project.

Also, please note that it is not possible to build the IOS 4 project for the simulator because it uses the AVCaptureSession class.

Apple's iTunes store will no longer accept applications that use the UIGetScreenImage function. This means that it is not possible to build an iphone app for IOS 3 that uses our toolkit and will be accepted by the iTunes store. Do not base your app on the iBardecode_os3 project if you wish to distribute it through the iTunes store. The iBardecode_ios4 folder contains a sample project written for IOS 4 that use the AVCaptureSession class to capture video frames from the camera. 

Any problems - please email support@bardecode.com
