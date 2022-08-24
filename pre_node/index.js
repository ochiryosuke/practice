const express = require('express');
const ejs = require('ejs');

var app = express();
app.engine('ejs',ejs.renderFile);

const bodyparser = require('body-parser');
app.use(bodyparser.urlencoded({extended: false}));

app.get('/',(req,res) => {
    var msg = 'this is index page<br>'
        + 'メッセージを書いて送信してみてください';

    res.render('index.ejs',
        {
            title: 'index',
            content: msg,
        }
    );
});


//post形式のときの処置
app.post('/',(req,res) => {
    var msg = 'this is post page<br>'
        + 'あなたは「<b>'+ req.body.message + '」</b>と送信しました。';

    res.render('index.ejs',{
        title: 'post',
        content: msg,
    });
});

app.listen(3000,()=>{
    console.log('sever start');
});