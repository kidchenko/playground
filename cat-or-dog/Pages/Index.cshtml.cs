using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cat_or_dog.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace cat_or_dog.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly FeatureFlagService _featureFlagService;
        private static readonly Random _random = new();

        public string Picture { get; set; }
        public bool IsKittenButtonEnabled { get; set; }
        public bool IsPuppyButtonEnabled { get; set; }


        public IndexModel(ILogger<IndexModel> logger, FeatureFlagService featureFlagService)
        {
            _logger = logger;
            _featureFlagService = featureFlagService;
        }

        public async Task OnGet()
        {
            var number = _random.Next(1, 11);
            var featureValue = await _featureFlagService.GetFeatureValue("home-image-banner");
            IsPuppyButtonEnabled = await _featureFlagService.HasFeatureFlag("home-is-puppy-button");
            IsKittenButtonEnabled = await _featureFlagService.HasFeatureFlag("home-is-kitten-button");


            Picture = number < int.Parse(featureValue) ?
                $"https://cataas.com/cat?{DateTime.Now.Ticks}" :
                "https://placedog.net/500?random";
        }
    }
}
