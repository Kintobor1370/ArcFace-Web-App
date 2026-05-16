# ArcFace Web App

A web application for calculating and displaying the similarity rate between two user-selected face images.

This application follows a distributed architecture and is separated into client and server components using the MVC design pattern. The server is built with C# and .NET, while the client is web-based. The server uses the [ArcFace face recognition model](https://huggingface.co/garavv/arcface-onnx) together with a [custom-built NuGet package](https://www.nuget.org/packages/Kintobor.ArcFace.Locks.Embeddings/) to generate embedding vector of uploaded images.

## Server Functions:
- Processing uploaded face images
- Generating embedding vectors using ArcFace model
- Managing access to the SQLite database
- Storing previously processed images
- Posting image data to the client upon request

## Web Client Functions:
- Uploading images to the server
- Requesting stored image data
- Selecting images for comparison
- Displaying results of face similarity calculation

## Features
- Upload face images from your device and add it to the database
- Display all images currently stored in the database
- Notify the user when the database is empty
- Select two uploaded images for comparison using dropdown menus
- Confirm image selection before starting comparison
- Calculate and display:
  - Facial distance
  - Similarity rate
- Delete all stored images from the database

## Requirements
- Windows 10 or later
- .NET 8.0 SDK
- ArcFace ONNX model file

# To set up the application:
1. Clone this repository.
2. Download the ArcFace model from the [official ONNX GitHub page](https://github.com/onnx/models/blob/main/validated/vision/body_analysis/arcface/model/arcfaceresnet100-8.onnx).
3. Place the _arcfaceresnet100-8.onnx_ file in the root directory of the application.
4. Start the server application from the _Server_ directory with the following command prompt:
   ```
   dotnet run
   ```
5. Start the web client from the _WebClient_ directory by opening _index.html_

## Examples of the Web Client UI

### Initial State (Empty Database)
<img width="549" height="565" alt="image_2026-05-07_21-58-32" src="https://github.com/user-attachments/assets/a3231811-a078-430e-9dd7-5124999a0aee" /><br>

### After Uploading Images
<img width="552" height="783" alt="image_2026-05-07_22-55-21" src="https://github.com/user-attachments/assets/02716378-fe7f-4595-9811-899703a5101c" /><br>

### Successful Distance and Similarity Calculation
<img width="564" height="789" alt="image_2026-05-07_22-06-02" src="https://github.com/user-attachments/assets/2c9de763-351c-40a9-a880-6d38d7d52db4" /><br>

### Warning for Unselected Images
<img width="550" height="558" alt="image_2026-05-07_22-07-05" src="https://github.com/user-attachments/assets/517ff1f5-a723-4d52-9471-32fa5cf53963" />
