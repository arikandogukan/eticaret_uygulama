﻿using eticaret_uygulama.Data;
using Microsoft.AspNetCore.Mvc;

namespace eticaret_uygulama.Component
{
    public class SliderList:ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public SliderList(ApplicationDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var result =_context.Sliders.ToList();
            return View(result);
        }
    }
}
