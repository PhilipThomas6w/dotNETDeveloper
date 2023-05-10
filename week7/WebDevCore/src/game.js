var title = "Burst My Bubble";
let developer = "Philip Luke Thomas";

const BALLOON_TOTAL = 20;
const balloons = [];
let score = 0;

function greeting() {
  let gameTitleText = `${title} - by - ${developer}`;
  let gameTitle = document.getElementById("game-title");
  gameTitle.innerHTML = gameTitleText;
}

function setup() {
  let canvas = createCanvas(640, 480);
  canvas.parent("game-container");

  for (let i = 0; i < BALLOON_TOTAL; i++) {
    balloons.push(
      new Balloon(
        random(width),
        random(height),
        33,
        color(random(255), random(255), random(255))
      )
    );
  }

  // Add reset button
  let resetButton = document.createElement("button");
  resetButton.id = "reset-button";
  resetButton.innerHTML = "New Game";
  resetButton.addEventListener("click", resetGame); // will call resetGame() if reset button is clicked

  document.getElementById("game-container").appendChild(resetButton);

  hideResetButton();
}

function draw() {
  background(135, 206, 235);

  for (let balloon of balloons) {
    balloon.blowAway();
    balloon.checkToPop();
    fill(balloon.color);
    circle(balloon.x, balloon.y, balloon.r);
  }

  if (score === BALLOON_TOTAL) {
    youWin(); // calls youWin()
  }
}

function youWin() {
  noLoop(); // stops continuous execution of draw()

  let para = document.createElement("p");
  para.id = "win-message";
  para.style.fontSize = "64px";
  let textNode = document.createTextNode("You win!");
  para.appendChild(textNode);

  let resetButton = document.getElementById("reset-button");
  resetButton.style.display = "block";

  document.getElementById("game-container").appendChild(para);
  document.getElementById("game-container").appendChild(resetButton); // shows the reset button
}

function resetGame() {
  score = 0;
  document.getElementById("score").innerHTML = score;

  balloons.length = 0;
  for (let i = 0; i < BALLOON_TOTAL; i++) {
    balloons.push(
      new Balloon(
        random(width),
        random(height),
        33,
        color(random(255), random(255), random(255))
      )
    );
  }

  hideResetButton();
  removeWinMessage();

  let canvas = createCanvas(640, 480);
  canvas.parent("game-container");

  loop(); //restarts continuous execution of draw()
}

function hideResetButton() {
  let resetButton = document.getElementById("reset-button");
  resetButton.style.display = "none";
}

function removeWinMessage() {
  let winMessage = document.getElementById("win-message");
  if (winMessage) {
    winMessage.remove();
  }
}
