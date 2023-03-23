#
# Script.ps1
#
# List of YouTube video IDs
$videoIds = @(
    "ILtz5nX3_fc",
    "GNGH6E7-pFQ",
    "dQw4w9WgXcQ",
    "989-7xsRLR4",
    "ZZ5LpwO-An4",
    "r5_NvFTfAWc",
    "XgztfRBc2jM"
    
)

# Get a random video ID from the list
$randomIndex = Get-Random -Minimum 0 -Maximum $videoIds.Length
$videoId = $videoIds[$randomIndex]

# Open the video in the default web browser
$videoUrl = "https://www.youtube.com/watch?v=$videoId"
Start-Process $videoUrl