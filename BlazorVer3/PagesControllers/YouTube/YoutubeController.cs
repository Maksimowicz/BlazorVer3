using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;


namespace BlazorVer3.PagesControllers.YouTube
{
    public class YoutubeController
    {
        private string apiKey = "";

       public VideoListResponse getMostViewed()
        {
            var initi = new Google.Apis.Services.BaseClientService.Initializer();
            initi.ApiKey = apiKey;
            YouTubeService ytService = new YouTubeService(initi);
            
            var a = ytService.Videos.List("snippet");
            a.Chart = VideosResource.ListRequest.ChartEnum.MostPopular;

            VideoListResponse response = a.Execute();

           

            return response;
        }

        public CommentThreadListResponse getYTComments(string id)
        {
            var initi = new Google.Apis.Services.BaseClientService.Initializer();
            initi.ApiKey = apiKey;
            YouTubeService ytService = new YouTubeService(initi);
            var a = ytService.CommentThreads.List("snippet");
            //var a = ytService.Comments.List("snippet");
            a.VideoId = id;
            

            CommentThreadListResponse response = a.Execute();
          
            return response;
        }
    }
}
