﻿//Copyright (c) 2014 Sang Ki Kwon (Cranberrygame)
//Email: cranberrygame@yahoo.com
//Homepage: http://www.github.com/cranberrygame
//License: MIT (http://opensource.org/licenses/MIT)
using System;
using System.Windows;
using System.Runtime.Serialization;
using WPCordovaClassLib.Cordova;
using WPCordovaClassLib.Cordova.Commands;
using WPCordovaClassLib.Cordova.JSON;
using System.Diagnostics; //Debug.WriteLine
//
using GoogleAds;
using System.Windows.Controls;
using Microsoft.Phone.Controls;

namespace Cordova.Extension.Commands {
    public class Admob : BaseCommand {
		
		public void setUp(string args) {
            string adUnit = JsonHelper.Deserialize<string[]>(args)[0];
            string adUnitFullScreen = JsonHelper.Deserialize<string[]>(args)[1];
            bool isOverlap = Convert.ToBoolean(JsonHelper.Deserialize<string[]>(args)[2]);
            bool isTest = Convert.ToBoolean(JsonHelper.Deserialize<string[]>(args)[3]);
            Debug.WriteLine("adUnit: " + adUnit);
            Debug.WriteLine("adUnitFullScreen: " + adUnitFullScreen);
            Debug.WriteLine("isOverlap: " + isOverlap);
            Debug.WriteLine("isTest: " + isTest);

            Deployment.Current.Dispatcher.BeginInvoke(() => {   
                _setUp(adUnit, adUnitFullScreen, isOverlap, isTest);
            });					
        }
		
        public void preloadBannerAd(string args) {
            Deployment.Current.Dispatcher.BeginInvoke(() => {   
                _preloadBannerAd();
            });
        }
		
        public void showBannerAd(string args) {
			string position=JsonHelper.Deserialize<string[]>(args)[0];
			string size=JsonHelper.Deserialize<string[]>(args)[1];
			Debug.WriteLine(position);
			Debug.WriteLine(size);
			
            Deployment.Current.Dispatcher.BeginInvoke(() => {
                _showBannerAd(position, size);
            });
        }

        public void reloadBannerAd(string args) {
            Deployment.Current.Dispatcher.BeginInvoke(() => {
                _reloadBannerAd();
            });
        }
		
        public void hideBannerAd(string args) {
            Deployment.Current.Dispatcher.BeginInvoke(() => {
                _hideBannerAd();
            });	
        }
		
        public void preloadFullScreenAd(string args) {
            Deployment.Current.Dispatcher.BeginInvoke(() => {
                _preloadFullScreenAd();
            });
        }
		
        public void showFullScreenAd(string args) {
            Deployment.Current.Dispatcher.BeginInvoke(() => {
                _showFullScreenAd();
            });		
        }
	
		//cranberrygame start: AdmobPluginDelegate
	
        private void _setUp(string adUnit, string adUnitFullScreen, bool isOverlap, bool isTest) {
			pluginDelegate._setUp(adUnit, adUnitFullScreen, isOverlap, isTest);
        }
		
        private void _preloadBannerAd() {
			pluginDelegate._preloadBannerAd();
        }
		
        private void _showBannerAd(string position, string size) {
			pluginDelegate._showBannerAd(position, size);
        }
      			
        private void _reloadBannerAd() {
			pluginDelegate._reloadBannerAd();
        }
		
        private void _hideBannerAd() {
            pluginDelegate._hideBannerAd();
        }
 	
        private void _preloadFullScreenAd() {
			pluginDelegate._preloadFullScreenAd();
        }
				
        private void _showFullScreenAd() {
			pluginDelegate._showFullScreenAd();
        }

		//cranberrygame end: AdmobPluginDelegate
    
		//cranberrygame start: Plugin
		
		public CallbackContext getCallbackContextKeepCallback() {
			return callbackContextKeepCallback;
		}
		
		public CordovaInterface getCordova() {
			return cordova;
		}
		
		public CordovaWebView getWebView() {
			return webView;
		}	

		//cranberrygame end: Plugin		
	}
}