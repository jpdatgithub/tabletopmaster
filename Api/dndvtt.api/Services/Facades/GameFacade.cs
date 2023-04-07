﻿using Microsoft.AspNetCore.SignalR;
using dndvtt.api.Services.Facades.Interfaces;
using dndvtt.api.Models.Chat;
using dndvtt.api.Services.Hubs.Clients;
using dndvtt.api.Services.Hubs;
using dndvtt.api.Models.Options;
using System.Text.Json;
using System;

namespace dndvtt.api.Services.Facades
{
    public class GameFacade : IGameFacade
    {
        private readonly IHubContext<GameHub, IGameClient>? _ttmHub;
        private Dictionary<string, List<string>> _options;

        public GameFacade(IHubContext<GameHub, IGameClient> ttmHub)
        {
            _ttmHub = ttmHub;

            // initialize options dictionary
            string jsonString = File.ReadAllText("../../Jsons/options.json");
            _options = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(jsonString)!;
        }

        public async Task SendMessageToAll(ChatMessage message)
        {
            await _ttmHub!.Clients.All.ReceiveMessage(message);
        }

        public GameOptionsModel StartGamePanel()
        {
            return new GameOptionsModel(new List<string>(_options["PlayerHand"]), "Player Hand");
        }
    }
}
