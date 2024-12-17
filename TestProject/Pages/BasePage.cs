﻿using Microsoft.Playwright;


namespace TestProject.Pages
{
    public abstract class BasePage
    {
        protected readonly IPage Page;

        protected BasePage(IPage page)
        {
            Page = page;
        }
    }
}
