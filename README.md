# linqpad-server

#### View and execute your LINQPad snippets over a Web API. Post input arguments and view standard output results over HTTP.

## Call this test.linq snippet:

![Image](C:\Q\git\LinqpadServer\images\snippet.png)

## Using this:

```bash
curl -X GET "http://localhost:2473/api/run/test"

>> ["Hello, world!"]
```

## Send input data (main args[]) using POST

```bash
curl -X POST -H "Content-Type: application/json" "http://localhost:2473/api/snippet/run/test" -d '"Hi! Ahoy! Welcome!"' 

>> ["Hi!","Ahoy!","Welcome!","Hello, world!"]
```

## List available snippets:

```bash
curl -X GET "http://localhost:2473/api/snippet/list"

>> ["test"]
```