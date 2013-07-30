//
//  iBardecodeViewController.m
//  iBardecode
//
//  Copyright Softek Software Ltd 2010. All rights reserved.
//

#import "iBardecodeViewController.h"
#import <AudioToolbox/AudioServices.h>

// The following code shows how you might use the Bardecode class to read barcodes on an iPhone.
//
// Barcodes are normally read by using the camera view finder as a scanner but it's also possible to read barcodes from images
// in the camera roll or by snapping a photo using the camera.
//
// The Bardecode object is created and initialized in viewdidLoad and the appropriate method called in buttonPress.
// The BardecodeDidFinish method is used to notify the view that barcode reading is complete or that the user hit cancel.


@implementation iBardecodeViewController

@synthesize result, value, type, doScan, readEAN13etc, readCode39etc, read2D;

// Call the correct method from the Bardecode class to read a barcode from either the camera roll, view finder or by taking a photo with the camera.
-(IBAction) buttonPress:(id) sender {
	barcode.ReadEAN13 = readEAN13etc.on ;
	barcode.ReadEAN8 = readEAN13etc.on ;
	barcode.ReadUPCE = readEAN13etc.on ;
	barcode.ReadUPCA = readEAN13etc.on ;
	barcode.ReadCode39 = readCode39etc.on ;
	barcode.ReadCode25 = readCode39etc.on ;
	barcode.ReadCode128 = readCode39etc.on ;
	barcode.ReadCodabar = readCode39etc.on ;
	barcode.ReadDatabar = readCode39etc.on ;
	barcode.ReadDatamatrix = read2D.on ;
	barcode.LicenseKey = @"E9430E3A85DB88FE9BFF3DED67300EB6" ;	
	

	[barcode ScanBarcodeFromViewFinder];
}
 
// Receive notification from the Bardecode class that the barcode reading is cimplete or has been cancelled.
// Possible notification names are BarcodeDidRead, BarcodeDidNotRead, UserDidCancel
- (void) BardecodeDidFinish:(NSNotification*)notification {
	if ([[notification name] isEqualToString:@"BarcodeDidRead"])
	{
		[self playBeep] ;
		result.text = @"Scanned Barcode OK";
		value.text = [barcode BarcodeValue] ;
		type.text = [barcode BarcodeType];
	}
	else if ([[notification name] isEqualToString:@"BarcodeDidNotRead"])
	{
		result.text = @"No Barcode Found";
		value.text = @"";
		type.text = @"";
	}
	else if ([[notification name] isEqualToString:@"UserDidCancel"])
	{
		result.text = @"User Cancelled";
		value.text = @"";
		type.text = @"";
	}
}


// Play a sound to indicate that a barcode has been read.
-(void) playBeep{
	//Get the filename of the sound file:
	NSString *path = [NSString stringWithFormat:@"%@%@",
					  [[NSBundle mainBundle] resourcePath],
					  @"/barcodeBeep.wav"];
	
	//declare a system sound id
	SystemSoundID soundID;
	
	//Get a URL for the sound file
	NSURL *filePath = [NSURL fileURLWithPath:path isDirectory:NO];
	
	//Use audio sevices to create the sound
	AudioServicesCreateSystemSoundID((CFURLRef)filePath, &soundID);
	
	//Use audio services to play the sound
	AudioServicesPlaySystemSound(soundID);
}


/*
// The designated initializer. Override to perform setup that is required before the view is loaded.
- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil {
    if (self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil]) {
        // Custom initialization
    }
    return self;
}
*/

/*
// Implement loadView to create a view hierarchy programmatically, without using a nib.
- (void)loadView {
}
*/


// Implement viewDidLoad to do additional setup after loading the view, typically from a nib.
// Create the barcode object.
- (void)viewDidLoad {
	result.text = @"";
	value.text = @"";
	type.text = @"";
	rotatingView = YES ;
	
	barcode = [Bardecode alloc] ;
	[barcode init] ;
	// This class will respond to BarcodeDidRead, BarcodeDidNotRead and UserDidCancel
	barcode.Delegate = self ;
	// Specify the UIView class that the video preview can be layered on top of.
	barcode.ViewForPreview = self.view ;
    [super viewDidLoad];
}



// Override to allow orientations other than
// the default portrait orientation.
- (BOOL)shouldAutorotateToInterfaceOrientation:(UIInterfaceOrientation)interfaceOrientation {
    // Return YES for supported orientations
    return rotatingView;
}


- (void)didRotateFromInterfaceOrientation:(UIInterfaceOrientation)fromInterfaceOrientation {
	[barcode ResizePreview];
}


- (void)didReceiveMemoryWarning {
	// Releases the view if it doesn't have a superview.
    [super didReceiveMemoryWarning];
	
	// Release any cached data, images, etc that aren't in use.
}

- (void)viewDidUnload {
	// Release any retained subviews of the main view.
	// e.g. self.myOutlet = nil;
}


- (void)dealloc {
	[barcode dealloc];
    [super dealloc];
}

@end
