# AspNetCore Streaming

This is a demo application showing how streaming work in AspNet Core.

The API has a single endpoint that returns an ```IEnumerable<int>```, 10k values are generated and yield every one second.

The Client is a console application that makes requests to the API and prints one line each time a new chunk of data is returned by the API.

Running both applications at the same time illustrates how streaming works in AspNet Core.

The API is hard-coded to listen at http://localhost:50001 and the client is hard-coded to make requests to the same address.