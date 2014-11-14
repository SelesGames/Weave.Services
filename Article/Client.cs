﻿using SelesGames.HttpClient;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Weave.Services.Article.Contracts;
using Incoming = Weave.Services.Article.DTOs.ServerIncoming;
using Outgoing = Weave.Services.Article.DTOs.ServerOutgoing;

namespace Weave.Services.Article.Client
{
    public class Client : IWeaveArticleService
    {
        const string SERVICE_URL = "http://weave-article.cloudapp.net/api/article/";




        #region Mark Read

        public async Task<bool> MarkRead(Guid userId, Incoming.SavedNewsItem newsItem)
        {
            if (userId == Guid.Empty) throw new ArgumentException("Not a valid userId");
            if (newsItem == null) throw new ArgumentNullException("newsItem can't be null");

            string append = "mark_read";
            var url = new UriBuilder(SERVICE_URL + append)
                .AddParameter("userId", userId)
                .ToString();

            var client = CreateClient();
            var result = await client.PostAsync<Incoming.SavedNewsItem, bool>(url, newsItem, CancellationToken.None);
            return result;
        }

        public async Task RemoveRead(Guid userId, Guid newsItemId)
        {
            if (userId == Guid.Empty) throw new ArgumentException("Not a valid userId");
            if (newsItemId == Guid.Empty) throw new ArgumentException("Not a valid newsItemId");

            string append = "remove_read";
            var url = new UriBuilder(SERVICE_URL + append)
                .AddParameter("userId", userId)
                .AddParameter("newsItemId", newsItemId)
                .AddCacheBuster()
                .ToString();

            var client = CreateClient();
            await client.GetAsync(url, CancellationToken.None);
        }

        public async Task<List<Outgoing.SavedNewsItem>> GetRead(Guid userId, int take, int skip = 0)
        {
            if (userId == Guid.Empty) throw new ArgumentException("Not a valid userId");

            string append = "get_read";
            var url = new UriBuilder(SERVICE_URL + append)
                .AddParameter("userId", userId)
                .AddParameter("take", take)
                .AddParameter("skip", skip)
                .AddCacheBuster()
                .ToString();

            var client = CreateClient();
            var result = await client.GetAsync<List<Outgoing.SavedNewsItem>>(url, CancellationToken.None);
            return result;
        }

        #endregion




        #region Favorite

        public async Task<bool> AddFavorite(Guid userId, Incoming.SavedNewsItem newsItem)
        {
            if (userId == Guid.Empty) throw new ArgumentException("Not a valid userId");
            if (newsItem == null) throw new ArgumentNullException("newsItem can't be null");

            string append = "add_favorite";
            var url = new UriBuilder(SERVICE_URL + append)
                .AddParameter("userId", userId)
                .ToString();

            var client = CreateClient();
            var result = await client.PostAsync<Incoming.SavedNewsItem, bool>(url, newsItem, CancellationToken.None);
            return result;
        }

        public async Task RemoveFavorite(Guid userId, Guid newsItemId)
        {
            if (userId == Guid.Empty) throw new ArgumentException("Not a valid userId");
            if (newsItemId == Guid.Empty) throw new ArgumentException("Not a valid newsItemId");

            string append = "remove_favorite";
            var url = new UriBuilder(SERVICE_URL + append)
                .AddParameter("userId", userId)
                .AddParameter("newsItemId", newsItemId)
                .AddCacheBuster()
                .ToString();

            var client = CreateClient();
            await client.GetAsync(url, CancellationToken.None);
        }

        public async Task<List<Outgoing.SavedNewsItem>> GetFavorites(Guid userId, int take, int skip = 0)
        {
            if (userId == Guid.Empty) throw new ArgumentException("Not a valid userId");

            string append = "get_favorites";
            var url = new UriBuilder(SERVICE_URL + append)
                .AddParameter("userId", userId)
                .AddParameter("take", take)
                .AddParameter("skip", skip)
                .AddCacheBuster()
                .ToString();


            var client = CreateClient();
            var result = await client.GetAsync<List<Outgoing.SavedNewsItem>>(url, CancellationToken.None);
            return result;
        }

        #endregion




        SmartHttpClient CreateClient()
        {
            return new SmartHttpClient();
        }
    }
}
