## LINQPad Mock HTTP Server

Hey, this is a basic mock HTTP server built in LINQPad. It's nothing fancy, but it does the trick.

### What It Does:
- Lets you set up mock routes with HTTP methods and responses.
- Logs incoming requests. Useful to see what's hitting the server.

### Using It:
1. Pop the code into LINQPad.
2. Run it.
3. Add your routes in the grid.
4. Hit the "Start" button.
5. Make requests to `http://localhost:8080/your_route`.
6. See logs for any hits.

### Heads Up:
- It uses `Microsoft.AspNetCore.Mvc.NewtonsoftJson (6.0.12)` so make sure it's added.
- If it's not working, check if something else is hogging port 8080.

### Maybe Later:
- Adding JSON response config.
- Letting you pick the port.