using DIDemoConAppCS;

Operations operations = new Operations(new DataWriter());
//operations.writer = new DataWriter(); // Using LogWriter

operations.WriteMyData(10, new LogWriter());

operations.PerformOperation("SampleOperation");

operations.WriteMyData(10);