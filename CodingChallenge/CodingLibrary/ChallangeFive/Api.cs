using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace CodingLibrary.ChallangeFive
{
    /// <summary>
    /// This a generic async api class to handle a mobile app restfull calls with a callback to the calling screens. With generics you define expected response and request type and it does all app error handling for errors within the api calls
    /// </summary>
    public class Api
    {
#if false
        public delegate void ApiCallback<TResponse>(TResponse message) where TResponse : Response;

        private static bool isAuthenticated;

        public static bool IsAuthenticated
        {
            get
            {
                return isAuthenticated;
            }
            set
            {
                isAuthenticated = value;
            }
        }

        private string token;
        HttpClient client;
        private Page caller;
        public Api(Page page)
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Add("Accept-Language", AppResources.Culture.TwoLetterISOLanguageName);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.Timeout = new TimeSpan(0, 0, 30);

            caller = page;

        }
        private async void HandleError(Response response)
        {
            StringBuilder sb = new StringBuilder();
            if (response != null && response.Messages != null)
            {
                foreach (var item in response.Messages)
                {
                    sb.AppendLine(item);
                }
                await caller.DisplayAlert(AppResources.Error, sb.ToString(), AppResources.Ok);
            }
        }

        public async Task Post<T, R>(ApiCallback<T> result, R request, string location) where T : Response
        {
            try
            {
                Acr.UserDialogs.UserDialogs.Instance.ShowLoading(AppResources.Loading);

                var uri = new Uri(url + location);

                T instance = default(T);

                string text = JsonConvert.SerializeObject(request);
                var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, uri);
                requestMessage.Content = content;
                string token = Settings.Local.Get<String>("token");
                requestMessage.Headers.Add("Authorization", "Bearer " + token);
                HttpResponseMessage response = await client.SendAsync(requestMessage);

                if (response.IsSuccessStatusCode)
                {
                    instance = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
                    if (instance.Success)
                    {
                        result(instance);
                    }
                    else
                    {
                        HandleError(instance);
                    }
                }
                else
                {
                    await caller.DisplayAlert(AppResources.Error, AuthenticationResources.ErrorLogin, AppResources.Ok);

                }
            }
            catch (Exception ex)
            {
                await caller.DisplayAlert(AppResources.Error, AuthenticationResources.ErrorLogin, AppResources.Ok);
            }
            finally
            {
                Acr.UserDialogs.UserDialogs.Instance.HideLoading();

            }
        }
        public async Task Post<T>(ApiCallback<T> result, string id, string location) where T : Response
        {
            try
            {
                Acr.UserDialogs.UserDialogs.Instance.ShowLoading(AppResources.Loading);

                var uri = new Uri(url + location);

                T instance = default(T);

                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, uri + "/" + id);
                string token = Settings.Local.Get<String>("token");
                requestMessage.Headers.Add("Authorization", "Bearer " + token);
                HttpResponseMessage response = await client.SendAsync(requestMessage);

                if (response.IsSuccessStatusCode)
                {
                    //Registration succesfull.
                    instance = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
                    if (instance.Success)
                    {
                        result(instance);
                    }
                    else
                    {
                        HandleError(instance);
                    }
                }
                else
                {
                    await caller.DisplayAlert(AppResources.Error, AuthenticationResources.ErrorLogin, AppResources.Ok);

                }
            }
            catch (Exception ex)
            {
                await caller.DisplayAlert(AppResources.Error, AuthenticationResources.ErrorLogin, AppResources.Ok);
            }
            finally
            {
                Acr.UserDialogs.UserDialogs.Instance.HideLoading();

            }
        }
        public async Task Get<T>(ApiCallback<T> result, string location, bool showLoading = true) where T : Response
        {
            try
            {
                if (showLoading)
                {
                    Acr.UserDialogs.UserDialogs.Instance.ShowLoading(AppResources.Loading);
                }

                var uri = new Uri(url + location);

                T instance = default(T);

                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
                string token = Settings.Local.Get<String>("token");
                requestMessage.Headers.Add("Authorization", "Bearer " + token);
                HttpResponseMessage response = await client.SendAsync(requestMessage);

                if (response.IsSuccessStatusCode)
                {
                    //Registration succesfull.
                    instance = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
                    result(instance);

                    if (!instance.Success)
                    {
                        HandleError(instance);
                    }
                }
                else
                {
                    await caller.DisplayAlert(AppResources.Error, AuthenticationResources.ErrorLogin, AppResources.Ok);

                }
            }
            catch (Exception ex)
            {
                await caller.DisplayAlert(AppResources.Error, AuthenticationResources.ErrorLogin, AppResources.Ok);
            }
            finally
            {
                if (showLoading)
                {
                    Acr.UserDialogs.UserDialogs.Instance.HideLoading();
                }
            }
        }
#endif
    }
}
