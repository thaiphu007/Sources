//
//  Bardecode.h
//  iBardecode
//
//  Copyright 2010 Softek Software Ltd. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <AVFoundation/AVFoundation.h>
#include "../../barcode.h"

#if TARGET_IPHONE_SIMULATOR
@interface Bardecode : NSObject <UINavigationControllerDelegate, UIImagePickerControllerDelegate>
#else
@interface Bardecode : NSObject <UINavigationControllerDelegate, UIImagePickerControllerDelegate, AVCaptureVideoDataOutputSampleBufferDelegate>
#endif
{
	bool ReadCode39 ;
	bool ReadCode128 ;
	bool ReadCodabar ;
	bool ReadDatabar ;
	bool ReadDatamatrix ;
	bool ReadEAN8 ;
	bool ReadEAN13 ;
	bool ReadUPCA ;
	bool ReadUPCE ;
	bool ReadCode25 ;
	bool ReadCode25ni;
	bool WaitForFocus;
	NSString *BarcodeValue ;
	NSString *BarcodeType ;
	UIViewController *Delegate ;
	UIImagePickerController * picker;
	NSTimer *scanTimer;
	NSString *LicenseKey;
	UIButton *CancelButton ;
	UIButton *TestButton ;
	UIView	*ViewForPreview ;
	UIImageView *BackgroundImageView ;
	UIImageView *OverlayImageView ;
	UIImage *BackgroundImage ;
	UIImage *OverlayImage ;
	UIImageView *TestImageView ;
	UIImage *TestImage ;
	bool haveReadBarcode ;
	bool AutoRotate ;
	bool haveDonePreviewSetup ;
#if ! TARGET_IPHONE_SIMULATOR
	AVCaptureSession *Session ;
	AVCaptureDevice *Device ;
	AVCaptureVideoPreviewLayer *PreviewLayer;
#endif	
}

- (int) ScanBarcodeFromBitmap:(CGImageRef) inImage;
- (NSString*) BarcodeValue ;
- (NSString*) BarcodeType ;
- (UIViewController*) Delegate ;
- (void) setWaitForFocus: (bool)input;
- (void) setReadCode39: (bool)input;
- (void) setReadCode128: (bool)input;
- (void) setReadCodabar: (bool)input;
- (void) setReadDatabar: (bool)input;
- (void) setReadDatamatrix: (bool)input;
- (void) setReadEAN8: (bool)input;
- (void) setReadEAN13: (bool)input;
- (void) setReadUPCA: (bool)input;
- (void) setReadUPCE: (bool)input;
- (void) setReadCode25: (bool)input;
- (void) setReadCode25ni: (bool)input;
- (void) setDelegate: (UIViewController *)input;
- (void) ScanBarcodeFromCameraRoll;
- (void) ScanBarcodeFromViewFinder;
- (void) ScanBarcodeFromCamera;
- (void) sendNotification: (NSString *)name;
- (void) setLicenseKey: (NSString *)input;
- (void) setBarcodeValue: (NSString *) input;
- (void) setBarcodeType: (NSString *) input;
- (void) setViewForPreview:(UIView *)input;
- (void) setBackgroundImageView:(UIImageView *)input ;
- (void) setOverlayImageView:(UIImageView *)input ;
- (void) setTestImageView:(UIImageView *)input ;
- (void) setBackgroundImage:(UIImage *)input ;
- (void) setOverlayImage:(UIImage *)input ;
- (void) setTestImage:(UIImage *)input ;
- (void) removeViews;
- (void) addViews;
- (void) setCancelButton: (UIButton *) input;
- (void) setTestButton: (UIButton *) input;
- (void) setupPreview;
- (UIView *) getViewForPreview;
- (void) ResizePreview;
- (UIViewController*)getViewController;
- (void) emptyResults;
- (void)setupCaptureSession;
-(void) cleanUpVideoCapture ;
-(void) captureSuccess ;
-(void) showIdleState ;
-(void) showBusyState ;
- (void)	restoreImageView: (UIImageView *) view
			  Orientation: (UIInterfaceOrientation) orientation;

#if ! TARGET_IPHONE_SIMULATOR
- (void)captureOutput:(AVCaptureOutput *)captureOutput 
	didOutputSampleBuffer:(CMSampleBufferRef)sampleBuffer 
	   fromConnection:(AVCaptureConnection *)connection;
- (CGImageRef) imageFromSampleBuffer:(CMSampleBufferRef) sampleBuffer;
- (void) setSession: (AVCaptureSession *) input;
- (void) setDevice: (AVCaptureDevice *) input;
- (void) setPreviewLayer: (AVCaptureVideoPreviewLayer *) input;
#endif

@end

@interface NSObject(NSWindowNotifications)
- (void)BardecodeDidFinish:(NSNotification*)notification;
@end
