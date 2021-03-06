const got = require("got");
const express = require("express");
const app = express();

let override = {
  16687466: null,
};

let addition = {};

// Parse JSON bodies (as sent by API clients)
app.use(express.json());

app.get("/item/*", async (req, res) => {
  console.log("get item", req.path);
  const itemId = req.path.split("/")[2];
  try {
    let data = await got(`https://api.portcalc.website${req.path}`);
    let replyJSON = JSON.parse(data.body);

    let ids = Object.keys(override);
    console.log(itemId, addition[itemId]);
    if (addition[itemId]) {
      for (let add of addition[itemId]) {
        replyJSON.tran.unshift(override[add]);
      }
    }

    for (let i = 0; i < replyJSON.tran.length; i++) {
      if (ids.includes(replyJSON.tran[i].id)) {
        if (override[replyJSON.tran[i].id] == null) {
          replyJSON.tran.splice(i, 1);
        } else {
          replyJSON.tran[i] = override[replyJSON.tran[i].id];
        }
      }
    }

    res.send(JSON.stringify(replyJSON));
  } catch (e) {
    console.error(e);
  }
  res.end();
});

app.get("*", async (req, res) => {
  console.log("get path", req.path);
  try {
    let data = await got(`https://api.portcalc.website${req.path}`);
    res.send(data.body);
  } catch (e) {
    console.error(e);
  }
  res.end();
});

app.delete("*", async (req, res) => {
  //delete transaction by id
  console.log(req.path);
  override[req.path.replace("/", "")] = null;
  res.end();
});

app.put("*", async (req, res) => {
  //edit existing transaction
  console.log("PUT!", req.body);
  override[req.body.id] = req.body;
  res.end();
});

app.post("*", async (req, res) => {
  //create new transaction
  console.log("POST!", req.body);
  req.body.id = Date.now();

  override[req.body.id] = req.body;

  if (addition[req.body.ItemId]) {
    addition[req.body.ItemId].push(req.body.id);
  } else {
    addition[req.body.ItemId] = [req.body.id];
  }
  res.end();
});

app.listen(80);
