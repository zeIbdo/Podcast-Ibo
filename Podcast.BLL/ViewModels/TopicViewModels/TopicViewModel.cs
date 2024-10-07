using Podcast.BLL.ViewModels.EpisodeViewModels;
namespace Podcast.BLL.ViewModels.TopicViewModels;

public class TopicViewModel : IViewModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? CoverUrl { get; set; }
    public List<EpisodeViewModel>? Episodes {  get; set; }
}
