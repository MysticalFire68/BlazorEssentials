﻿using CloudNimble.BlazorEssentials.Navigation;
using CloudNimble.EasyAF.Configuration;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;

namespace CloudNimble.BlazorEssentials.TestApp.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class AppState : AppStateBase
    {
        #region Private Members

        private readonly ConfigurationBase config;

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="navigationManager"></param>
        /// <param name="httpClientFactory"></param>
        /// <param name="config"></param>
        public AppState(NavigationManager navigationManager, IHttpClientFactory httpClientFactory, IJSRuntime jsRuntime, IWebAssemblyHostEnvironment environment, ConfigurationBase config)
            : base(navigationManager, httpClientFactory, jsRuntime, environment)
        {
            if (!Environment.IsProduction())
            {
                StateHasChanged.DebugMode = StateHasChangedDebugMode.Info;
            }
            StateHasChanged.DelayMode = StateHasChangedDelayMode.Throttle;
            StateHasChanged.DelayInterval = 100;

            this.config = config;
            var nav = new List<NavigationItem>
            {
                new NavigationItem("Dashboard",             "fad fa-fw fa-desktop", "/",                    "Main",             true, "Dashboard",              "fad fa-fw fa-2x fa-desktop", null, true),
                new NavigationItem("LoadingContainer Demo", "fad fa-fw fa-desktop", "LoadingContainer",     "Controls",         true, "LoadingContainer Demo",  "fad fa-fw fa-2x fa-desktop", null, true),
                new NavigationItem("Merlin Demo",           "fad fa-fw fa-desktop", "Merlin",               "Controls",         true, "Merlin Demo",            "fad fa-fw fa-2x fa-desktop", null, true),
                new NavigationItem("Delay StateHasChanged", "fad fa-fw fa-desktop", "DelayStateHasChanged", "Functionality",    true, "Delay StateHasChanged",  "fad fa-fw fa-2x fa-desktop", null, true)
            };
            LoadNavItems(nav);
            PropertyChanged += AppState_PropertyChanged;
        }

        #endregion

        #region Event Handlers

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        private void AppState_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Console.WriteLine($"AppState.{e.PropertyName} changed.");
            StateHasChanged.Action();
        }
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

        #endregion

    }


}
