# ConvertXMLsToCSV
A single helper program to convert some specific XML to CSV.

## Why I did this?

I was learning some ML stuff here:

https://pyimagesearch.com/2020/10/05/object-detection-bounding-box-regression-with-keras-tensorflow-and-deep-learning/

At a given point I wanted to apply those learnings to a particular case.

For that purpose, I needed a dataset of images with soccer balls, each image already classified with a bounding box around the ball (top-left and bottom-right pixel coordinates of the bounding box, inside the image).

I found such dataset here: https://makeml.app/soccer-ball-tutorial

It came with a bunch of XML files (one for each image) with the information I needed.

But I needed that information to be gathered in a single CSV file to be used in the pyImageSearch 

But I also found that not only I would like to apply 


## How to use

Currently, I did this in a hurry and the steps are a bit cumbersome.

I expect to improve this application with time, as I am going to use it with different datasets and to different purposes.

So expect this application to become more generic and modular with time.

To use this with the current limitations:

1. Check .config file: edit the values here to match your paths.
2. Check CSVBuilder.ConvertDataToCsv: does it read the data from the expected dataset places?
3. Check CSVBuilder.ConvertDataToCsv: does it write the data to he expected CSV columns?
4. Build and run the application.

Currently, my personal steps are:

1. Do the steps 1-3 above.
2. Build and let it automatically copy the needed files to a .\tests\ folder (you have already my last build here).
3. Put the XML files in a .\tests\data\ folder (you have already some XML here).
4. Run the application in that folder.
5. It will generate a .\tests\output.csv file (you have already a file here).

## Future work

1. Automated tests.
2. Better modularity and code cohesion.
3. Accept paths as arguments (not only through configuration file).
4. Have a configurable way to map XML paths to CSV output columns.
5. Have a configurable way to choose the final CSV output columns.