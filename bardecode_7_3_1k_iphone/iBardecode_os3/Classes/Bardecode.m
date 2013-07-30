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
        [self setReadCode39:0];
        [self setReadCode128:0];
        [self setReadCodabar:0];
        [self setReadCode25:0];
        [self setReadCode25ni:0];
        [self setReadDatabar:0];
        [self setReadEAN13:0];
        [self setReadEAN8:0];
        [self setReadUPCA:0];
        [self setReadUPCE:0];
        [self setReadDatamatrix:0];
		[self setLicenseKey:@""];
		[self setBarcodeValue:@""];
		[self setBarcodeType:@""];

    }
    return self;
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
	
	// Set quiet zone size to around 10 pixels for a screen image and proportionally more for a higher res image
	val = bm.bmWidth / 32 ;
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

-(void) emptyResults
{
	[self setBarcodeValue:@""] ;
	[self setBarcodeType:@""] ;
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

-(void)onTimer                                                                                                    
{                                                                                                                                     
	if (scanTimer == nil)
		return ;
	
	scanTimer = nil ;
	
	extern CGImageRef UIGetScreenImage();
	CGImageRef image = UIGetScreenImage();
	
	int n = [self ScanBarcodeFromBitmap:image] ;

	CGImageRelease(image);
	
	if (n) {
		// Process barcode
		[picker dismissModalViewControllerAnimated:YES];
		[self sendNotification:@"BarcodeDidRead"];
	}
	else {
		scanTimer = [NSTimer scheduledTimerWithTimeInterval:0.3 target:self selector:@selector(onTimer) userInfo:nil repeats:NO];
	}
}   


-(void) ScanBarcodeFromViewFinder
{
	[self emptyResults];
	picker = [[UIImagePickerController alloc] init];
	
	picker.delegate = self;
	
	picker.sourceType = UIImagePickerControllerSourceTypeCamera;
	
	[Delegate presentModalViewController:picker animated:YES];
	
	scanTimer = [NSTimer scheduledTimerWithTimeInterval:3.0 target:self selector:@selector(onTimer) userInfo:nil repeats:NO];
	
}

-(void) ScanBarcodeFromCamera
{
	[self emptyResults];
	scanTimer = nil;
	
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

-(void)cancelTimer
{
	scanTimer = nil ;
}

- (void)imagePickerController:(UIImagePickerController *) pkr didFinishPickingMediaWithInfo:(NSDictionary *)info {
	[self cancelTimer] ;
	
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
	[self cancelTimer];
	[pkr dismissModalViewControllerAnimated:YES];
	[self sendNotification:@"UserDidCancel"] ;
}

@end
