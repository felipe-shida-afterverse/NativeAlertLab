#import  "UnityAppController.h"
#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>

@interface iOSBuildNumber : NSObject
@end

@implementation iOSBuildNumber

+(NSString*) getBuildNumber
{
    return [[NSBundle mainBundle] objectForInfoDictionaryKey:@"CFBundleVersion"];
}

char* CreateChar(const char* string)
{
    if (string == NULL)
        return NULL;
    
    char* res = (char*)malloc(strlen(string) + 1);
    strcpy(res, string);
    
    return res;
}

@end

extern "C" {
    const char * GetBuildNumber()
    {
        return CreateChar([[iOSBuildNumber getBuildNumber] UTF8String]);
    }
}
