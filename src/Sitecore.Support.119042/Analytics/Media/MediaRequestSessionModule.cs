using Sitecore.Analytics.Media;
using Sitecore.Resources.Media;
using System;
using System.Web;
using Sitecore.Analytics.Web;

namespace Sitecore.Support.Analytics.Media
{
  public class MediaRequestSessionModule : Sitecore.Analytics.Media.MediaRequestSessionModule
  {
    protected override bool IsSessionRequired()
    {
      if (!this.IsTrackerEnabled())
      {
        return false;
      }
      MediaRequest request = MediaManager.ParseMediaRequest(HttpContext.Current.Request);
      if (request == null)
      {
        return false;
      }
      MediaRequestTrackingInformation information = new MediaRequestTrackingInformation(request);
      if (information.IsTrackedRequest())
      {
        return true;
      }
      ContactKeyCookie cookie = new ContactKeyCookie("");
      return !cookie.IsClassificationGuessed;
    }



  }
}
