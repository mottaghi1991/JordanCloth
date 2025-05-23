﻿using Core.Interface.Admin;
using Core.Interface.Store;
using Domain.Store;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading.Tasks;

namespace Personal.Component.fourthFeature
{
   
        public class fourthFeature : ViewComponent
        {
            private readonly IProduct _product;
        private readonly ISiteSetting _siteSetting;
        private readonly IMemoryCache _memoryCache;

        public fourthFeature(IProduct product, ISiteSetting siteSetting, IMemoryCache memoryCache)
            {
                _product = product;
            _siteSetting = siteSetting;
            _memoryCache = memoryCache;
        }
            public async Task<IViewComponentResult> InvokeAsync()
            {
            var cachkey = "fourthFeature";
            if (!_memoryCache.TryGetValue(cachkey, out object obj))
            {
                // بار اول: مقداردهی از دیتابیس
                var sliderId = _siteSetting.GetSitSetting().FourthSlider;
                obj = _product.GetProductByTagId(sliderId);

                // ذخیره در کش برای مثلا ۶ ساعت
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromDays(6));

                _memoryCache.Set(cachkey, obj, cacheEntryOptions);
            }



                return View("/Component/fourthFeature/fourthFeature.cshtml", obj);
            }
        }
    
}
