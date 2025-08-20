using IT7BDIDemo;

Processing processing = new Processing(new DataWriter());

//processing.Writer = new DataWriter(); // or new DataWriter() based on your requirement

processing.PrintMyData("Hello, this is a test message for IT7BDIDemo.");

processing.PrintMyData("New Values", new LogWriter());