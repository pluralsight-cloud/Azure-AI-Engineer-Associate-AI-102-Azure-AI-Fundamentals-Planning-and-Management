#Get your endpoints setup
#setx AI_SVC_KEY YOURKEY
#setx AI_SVC_ENDPOINT YOURENDPOINT

import requests
import json
import os

#Authenticate
subscription_key = os.environ["AI_SVC_KEY"]
endpoint = os.environ["AI_SVC_ENDPOINT"]

#Source image file
read_image_url = "https://github.com/johnthebrit/RandomStuff/raw/master/Whiteboards/RAG.png"

#Construct the URL and header
ai_url = endpoint + "/computervision/imageanalysis:analyze?api-version=2024-02-01&features=read"
headers = {'Ocp-Apim-Subscription-Key': subscription_key}
params = {'language': 'en'}

#Call the endpoint with our image
response = requests.post(ai_url, headers=headers, params=params, json={"url": read_image_url})
response.raise_for_status()

# Print the response
print(response.json())
