//
//  iBardecodeViewController.h
//  iBardecode
//
//  Copyright Softek Software Ltd 2010. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface iBardecodeViewController : UIViewController {
	UIButton * choosePhoto;
	UIButton * takePhoto;
	UIButton * doScan;
	UISwitch * readEAN13etc ;
	UISwitch * readCode39etc ;
	UISwitch * read2D ;
	IBOutlet UILabel *result;
	IBOutlet UILabel *value ;
	IBOutlet UILabel *type ;
	Bardecode *barcode;
	bool	rotatingView;
}

@property (nonatomic, retain) IBOutlet UIButton * doScan;
@property (nonatomic, retain) IBOutlet UISwitch * readEAN13etc;
@property (nonatomic, retain) IBOutlet UISwitch * readCode39etc;
@property (nonatomic, retain) IBOutlet UISwitch * read2D;
@property (nonatomic, retain) UILabel *result;
@property (nonatomic, retain) UILabel *value;
@property (nonatomic, retain) UILabel *type;
-(IBAction) buttonPress:(id) sender;
-(void)playBeep;
-(void)BardecodeDidFinish:(NSNotification*)notification;




@end

