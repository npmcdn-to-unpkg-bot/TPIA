var selectedfile = document.getElementById('input').files[0];
var selectedFile = $('#input').get(0).files[0];
var selectedFile = $('#input')[0].files[0];
var inputElement = document.getElementById("inputField");
inputElement.addEventListener("change", handleFiles, false);

function handleFiles() {
  var fileList = this.files;
  /* now you can work with the file list */
}

var numFiles = files.length;
for (var i = 0; i < files.length; i++) {
  var file = files[i];
}

var fileSelect = document.getElementById("fileSelect"),
  fileElem = document.getElementById("fileElem");

fileSelect.addEventListener("click", function (e) {
  if (fileElem) {
    fileElem.click();
  }
  e.preventDefault(); // prevent navigation to "#"
}, false);

var dropbox;

dropbox = document.getElementById("dropbox");
dropbox.addEventListener("dragenter", dragenter, false);
dropbox.addEventListener("dragover", dragover, false);
dropbox.addEventListener("drop", drop, false);

function dragenter(e) {
  e.stopPropagation();
  e.preventDefault();
}

function dragover(e) {
  e.stopPropagation();
  e.preventDefault();
}



function drop(e) {
  e.stopPropagation();
  e.preventDefault();

  var dt = e.dataTransfer;
  var files = dt.files;

  handleFiles(files);
}

function handleFiles(files) {
  for (var i = 0; i < files.length; i++) {
    var file = files[i];
    var imageType = /image.*/;

    if (!file.type.match(imageType)) {
      continue;
    }

    var img = document.createElement("img");
    img.classList.add("obj");
    img.file = file;
    preview.appendChild(img);

    var reader = new FileReader();
    reader.onload = (function (aImg) { return function (e) { aImg.src = e.target.result; }; })(img);
    reader.readAsDataURL(file);
  }
}

var objectURL = window.URL.createObjectURL(fileObj);
window.URL.revokeObjectURL(objectURL);

var fileSelect = document.getElementById("fileSelect"),
  fileElem = document.getElementById("fileElem"),
  fileList = document.getElementById("fileList");

fileSelect.addEventListener("click", function (e) {
  if (fileElem) {
    fileElem.click();
  }
  e.preventDefault(); // prevent navigation to "#"
}, false);

function handleFiles(files) {
  if (!files.length) {
    fileList.innerHTML = "<p>No files selected!</p>";
  }
  else {
    var list = document.createElement("ul");
    for (var i = 0; i < files.length; i++) {
      var li = document.createElement("li");
      list.appendChild(li);

      var img = document.createElement("img");
      img.src = window.URL.createObjectURL(files[i]);
      img.height = 60;
      img.onload = function () {
        window.URL.revokeObjectURL(this.src);
      }
      li.appendChild(img);

      var info = document.createElement("span");
      info.innerHTML = files[i].name + ": " + files[i].size + " bytes";
      li.appendChild(info);
    }
    fileList.appendChild(list);
  }
}

function sendFiles() {
  var imgs = document.querySelectorAll(".obj");

  for (var i = 0; i < imgs.length; i++) {
    new FileUpload(imgs[i], imgs[i].file);
  }
}

function FileUpload(img, file) {
  var reader = new FileReader();
  this.ctrl = createThrobber(img);
  var xhr = new XMLHttpRequest();
  this.xhr = xhr;

  var self = this;
  this.xhr.upload.addEventListener("progress", function (e) {
    if (e.lengthComputable) {
      var percentage = Math.round((e.loaded * 100) / e.total);
      self.ctrl.update(percentage);
    }
  }, false);

  xhr.upload.addEventListener("load", function (e) {
    self.ctrl.update(100);
    var canvas = self.ctrl.ctx.canvas;
    canvas.parentNode.removeChild(canvas);
  }, false);
  xhr.open("POST", "http://demos.hacks.mozilla.org/paul/demos/resources/webservices/devnull.php");
  xhr.overrideMimeType('text/plain; charset=x-user-defined-binary');
  reader.onload = function (evt) {
    xhr.sendAsBinary(evt.target.result);
  };
  reader.readAsBinaryString(file);
}

function fileUpload(file) {
  // Please report improvements to: marco.buratto at tiscali.it

  var fileName = file.name,
    fileSize = file.size,
    fileData = file.getAsBinary(), // works on TEXT data ONLY.
    boundary = "xxxxxxxxx",
    uri = "serverLogic.php",
    xhr = new XMLHttpRequest();

  xhr.open("POST", uri, true);
  xhr.setRequestHeader("Content-Type", "multipart/form-data, boundary=" + boundary); // simulate a file MIME POST request.
  xhr.setRequestHeader("Content-Length", fileSize);

  xhr.onreadystatechange = function () {
    if (xhr.readyState == 4) {
      if ((xhr.status >= 200 && xhr.status <= 200) || xhr.status == 304) {

        if (xhr.responseText != "") {
          alert(xhr.responseText); // display response.
        }
      }
    }
  }

  var body = "--" + boundary + "\r\n";
  body += "Content-Disposition: form-data; name='fileId'; filename='" + fileName + "'\r\n";
  body += "Content-Type: application/octet-stream\r\n\r\n";
  body += fileData + "\r\n";
  body += "--" + boundary + "--";

  xhr.send(body);
  return true;
}