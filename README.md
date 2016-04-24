# linqpad-server

Expose your snippets to the masses! View and execute your LINQPad snippets over a Web API. Post input arguments and view standard output results over HTTP.

#### Call this test.linq snippet:

![Image](https://raw.githubusercontent.com/jogleasonjr/linqpad-server/master/images/snippet.png)

#### Using this:

```bash
curl -X GET "http://localhost:2473/api/run/test"

>> ["Hello, world!"]
```

#### Send input data (main args[]) using POST

```bash
curl -X POST -H "Content-Type: application/json" "http://localhost:2473/api/snippet/run/test" -d '"Hi! Ahoy! Welcome!"' 

>> ["Hi!","Ahoy!","Welcome!","Hello, world!"]
```

#### List available snippets:

```bash
curl -X GET "http://localhost:2473/api/snippet/list"

>> ["test"]
```

### To build and run

Be sure you have lprun.exe in your PATH by enabling it during installation You may need to reinstall LINQPad to enable this option if you don't want to edit your PATH.

![Image](https://raw.githubusercontent.com/jogleasonjr/linqpad-server/master/images/installOption.png)

1. Get the code
  `git clone https://github.com/jogleasonjr/linqpad-server.git`
2. Open LinqpadServer.sln in Visual Studio 2015
3.(Optionally) Run all tests `Ctrl+R, A`
4. Set LinqpadServer.WebApi as the startup project
5. Build and Run (F5)
6. Verify port settings, and test with `curl -X GET "http://localhost:2473/api/snippet/list`

By default, the api will list the snippets in your `~/Documents/LINQPad Queries` folder. To override this, put an alternative directory [here](https://github.com/jogleasonjr/linqpad-server/blob/master/LinqpadServer.WebApi/Controllers/SnippetController.cs#L15).

The data you POST will simply transform into the `args[]` parameter in `main(string[] args)`. The results will be a string array of everything sent to `Console.WriteLine` or the `.Dump()` extension method.
