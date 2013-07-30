//
//  iBardecodeAppDelegate.h
//  iBardecode
//
//  Copyright Softek Software Ltd 2010. All rights reserved.
//

#import <UIKit/UIKit.h>

@class iBardecodeViewController;

@interface iBardecodeAppDelegate : NSObject <UIApplicationDelegate> {
    UIWindow *window;
    iBardecodeViewController *viewController;
}

@property (nonatomic, retain) IBOutlet UIWindow *window;
@property (nonatomic, retain) IBOutlet iBardecodeViewController *viewController;

@end

