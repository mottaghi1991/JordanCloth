using Core.Interface.Admin;
using Core.Interface.Store;
using Domain.Store;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personal.Component.FirstFeature
{
    public class FirstFeature : ViewComponent
    {
        private readonly IFeatureValue _featureValue;
        private readonly ISiteSetting _siteSetting;
        private readonly IMemoryCache _memoryCache;


        public FirstFeature(IFeatureValue featureValue, ISiteSetting siteSetting, IMemoryCache memoryCache)
        {
            _featureValue = featureValue;
            _siteSetting = siteSetting;
            _memoryCache = memoryCache;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cacheKey = "FirstFeature";
            if (!_memoryCache.TryGetValue(cacheKey, out List<FeatureValue> model))
            {
                // بار اول: مقداردهی از دیتابیس
                var sliderId = _siteSetting.GetSitSetting().FirstSlider;

                // همینجا ToList میکنی تا Context مصرف بشه و ببندیش
                model = _featureValue.GetFeatureValueByfeatureId(sliderId).ToList();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromDays(6));

                _memoryCache.Set(cacheKey, model, cacheEntryOptions);
            }

            return View("/Component/FirstFeature/FirstFeature.cshtml", model);
        }

    }
}
