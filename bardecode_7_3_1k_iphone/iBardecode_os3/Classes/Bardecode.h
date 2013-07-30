//
//  Bardecode.h
//  iBardecode
//
//  Copyright 2010 Softek Software Ltd. All rights reserved.
//

#import <Foundation/Foundation.h>
#include "../../barcode.h"

@interface Bardecode : NSObject <UINavigationControllerDelegate, UIImagePickerControllerDelegate> {
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
	NSString *BarcodeValue ;
	NSString *BarcodeType ;
	UIViewController *Delegate ;
	UIImagePickerController * picker;
	NSTimer *scanTimer;
	NSString *LicenseKey;
}

- (int) ScanBarcodeFromBitmap:(CGImageRef) inImage;
- (NSString*) BarcodeValue ;
- (NSString*) BarcodeType ;
- (UIViewController*) Delegate ;
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
- (void) cancelTimer;
- (void) onTimer;
- (void) setLicenseKey: (NSString *)input;
- (void) setBarcodeValue: (NSString *) input;
- (void ) setBarcodeType: (NSString *) input;
- (void) emptyResults;


@end

@interface NSObject(NSWindowNotifications)
- (void)BardecodeDidFinish:(NSNotification*)notification;
@end
