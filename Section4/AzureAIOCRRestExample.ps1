$endpoint = $env:AI_SVC_ENDPOINT
$read_image_url = "https://github.com/johnthebrit/RandomStuff/raw/master/Whiteboards/RAG.png"

$ai_url = $endpoint + "computervision/imageanalysis:analyze?api-version=2024-02-01&features=read&language=en"
$headers = @{
    'Content-Type'='application/json'
    'Ocp-Apim-Subscription-Key'=$env:AI_SVC_KEY
}
$body = @{
    "url"=$read_image_url
} | ConvertTo-Json

$resp = Invoke-RestMethod -Uri $ai_url -Method Post -Headers $headers -Body $body
$resp.readresult.blocks.lines