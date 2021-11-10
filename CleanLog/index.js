console.log("Starting CleanLog");

const express = require("express");
const app = express();
const port = 8080;

app.get("*", (req, res) => {
  const logString = decodeURI(req.path.slice(1, req.path.length));
  try {
    console.log(JSON.parse(logString));
  } catch (e) {
    console.log(logString);
  }
  res.send("OK");
});

app.listen(port, () => {
  console.log(`Listening on port : ${port}`);
});
