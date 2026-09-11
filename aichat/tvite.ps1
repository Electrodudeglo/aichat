Write-Host "Starting Tailwind watcher..." -ForegroundColor Cyan

npx @tailwindcss/cli -i ./Styles/input.css -o ./wwwroot/tailwind.css --watch