﻿using Microsoft.AspNetCore.Http;

namespace Podcast.BLL.ViewModels.SpeakerViewModels
{
    public class SpeakerViewModel : IViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }

        public List<ProfessionViewModel>? Professions { get; set; }
    }

    public class SpeakerCreateViewModel : IViewModel
    {
        public required string Name { get; set; }
        public required IFormFile ImageFile { get; set; }

    }

    public class SpeakerUpdateViewModel : IViewModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required IFormFile ImageFile { get; set; }

    }

    public class ProfessionViewModel : IViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
