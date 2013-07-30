//
//  iBardecodeAppDelegate.m
//  iBardecode
//
//  Copyright Softek Software Ltd 2010. All rights reserved.
//

#import "iBardecodeAppDelegate.h"
#import "iBardecodeViewController.h"

@implementation iBardecodeAppDelegate

@synthesize window;
@synthesize viewController;


- (void)applicationDidFinishLaunching:(UIApplication *)application {    
    
    // Override point for customization after app launch    
    [window addSubview:viewController.view];
    [window makeKeyAndVisible];
}


- (void)dealloc {
    [viewController release];
    [window release];
    [super dealloc];
}


@end
