# aichat

A Blazor WebAssembly chat app that talks to the OpenAI API using your own API key. Everything runs in your browser. There is no server or database behind it.

## What the app provides

- **Chat page**: talk to the AI assistant (model: `gpt-4-turbo`). Replies support Markdown (lists, code blocks, links). You can like a reply or copy it with one click. A dot in the header shows whether your API key works (green = Online, red = Offline).
- **API Key page**: paste your OpenAI API key. The app checks that it works before saving it. Use **Release** to remove it.
- **Usage page**: shows how many tokens you have used in the current session, and a list of your most recent replies. Arrows show whether each reply used more or fewer tokens than the one before.
- **New Chat button**: in the sidebar. It clears the current conversation and starts a fresh one.
- **Collapsible sidebar**: click the arrow to make the menu smaller.

## How it works

- **Your API key** is saved in your browser's `localStorage`. It stays there until you release it or clear your browser data. The browser sends it straight to OpenAI.
- **Your chat, likes and token usage** are only kept in memory while the tab is open. Nothing is saved, so **refreshing or closing the page discards the conversation**.
- **Only the last 10 messages** are sent to OpenAI with each new question. This keeps requests fast and cheap, but in long chats the assistant forgets the earliest messages.

> Anyone with access to your browser profile can read a key saved in `localStorage`. Only use this app on a computer you trust.

## Getting started

Requires the .NET 10 SDK and Node.js.

1. From the `aichat` project folder, install the styling dependencies: `npm install`
2. Generate the stylesheet: `npm run css:build` (or `npm run css:watch` while developing)
3. Run the app: `dotnet run`
4. Open the app in your browser, go to the **API Key** page and add your OpenAI key.

`wwwroot/tailwind.css` is generated and not committed, so step 2 is required on a fresh clone and before publishing.
