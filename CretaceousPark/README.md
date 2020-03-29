## Notes

#### What is an API?

API stands for **Application Programming Interface.**

An API isn’t the same as the remote server — rather it is **the part of the server that receives requests and sends responses.**

To summarize, when a company offers an API to their customers, it just means that they’ve built a set of dedicated URLs that return pure data responses — meaning the responses won’t contain the kind of presentational overhead that you would expect in a graphical user interface like a website.

#### API Example

_Example Scenario:_ Your small business’s website has a form used to sign clients up for appointments. You want to give your clients the ability to automatically create a Google calendar event with the details for that appointment.

_API use:_ The idea is to have your website’s server talk directly to Google’s server with a request to create an event with the given details. Your server would then receive Google’s response, process it, and send back relevant information to the browser, such as a confirmation message to the user.

Alternatively, your browser can often send an API request directly to Google’s server bypassing your server.

How is this Google Calendar’s API different from the API of any other remote server out there?

In technical terms, **the difference is the format of the request and the response.**

To render the whole web page, your browser expects a response in HTML, which contains presentational code, while Google Calendar’s API call would just return the data — likely in a format like JSON.

If your website’s server is making the API request, then your website’s server is the client (similar to your browser being the client when you use it to navigate to a website).

From your users perspective, APIs allow them to complete the action without leaving your website.
