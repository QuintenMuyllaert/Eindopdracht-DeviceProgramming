# Eindopdracht-DeviceProgramming

This is a project I made using C# & Xamarin.
It uses the pricecheck & trade API https://api.portcalc.website/.
This is a community made API that let's you check the recorded prices of rare / valuable items in the game RuneScape.

As this endpoint doesn't include PUT / DELETE I overridden the API with a custom wrapper that lets you do those methods.
This endpoint is written in JavaScript using NodeJS.
Build & run using `npm install && node index.js` withing the "API" folder.

There's also another Node applet named "CleanLog" I made this because I got sick of VisualStudio's cluttered output.
It's not required to run this applet but it exists.
Build & run using `npm install && node index.js` withing the "CleanLog" folder.