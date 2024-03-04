$endpoint = $env:AI_SVC_ENDPOINT
$read_image_url = "https://github.com/johnthebrit/RandomStuff/raw/master/Whiteboards/RAG.png"

$ai_url = $endpoint + "computervision/imageanalysis:analyze?api-version=2024-02-01&features=read&language=en"

#Get an Entra token
$token = Get-AzAccessToken -ResourceUrl https://cognitiveservices.azure.com/ #need a token for cognitive services
$headers = @{
    'Content-Type'='application/json'
    'Authorization'='Bearer ' + $token.Token
}

$body = @{
    "url"=$read_image_url
} | ConvertTo-Json

$resp = Invoke-RestMethod -Uri $ai_url -Method Post -Headers $headers -Body $body
$resp.readresult.blocks.lines