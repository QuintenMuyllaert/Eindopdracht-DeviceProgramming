const got = require("got");
const express = require("express");
const app = express();

let override = {
  16687466: null,
};

app.get("/item/*", async (req, res) => {
  console.log("get item", req.path);
  try {
    let data = await got(`https://api.portcalc.website${req.path}`);
    let replyJSON = JSON.parse(data.body);

    let ids = Object.keys(override);
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
  res.end(200);
});

app.put("*", async (req, res) => {
  //edit existing transaction

  res.end(200);
});

app.post("*", async (req, res) => {
  //create new transaction
  res.end(200);
});

app.listen(80);