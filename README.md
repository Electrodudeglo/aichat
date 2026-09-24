# aichat

A Blazor WebAssembly chat app that talks to the OpenAI API using your own API key. The key is stored in your browser only.

## Getting started

Requires the .NET 10 SDK and Node.js.

1. From the `aichat` project folder, install the styling dependencies: `npm install`
2. Generate the stylesheet: `npm run css:build` (or `npm run css:watch` while developing)
3. Run the app: `dotnet run`

`wwwroot/tailwind.css` is generated and not committed, so step 2 is required on a fresh clone and before publishing.
