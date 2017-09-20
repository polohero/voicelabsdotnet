# voicelabsdotnet
A dot net library for voice labs.

Below I've included the examples on how to use the SDK. 

You need to add a reference to VoiceLabs.Client to use. 

Below is the sample from VoiceLabs.Test with the unit tests.

A couple notes:
1. Remember to ignore Google Actions Health checks. That is not built into the client. https://developers.google.com/actions/console/actions-health-check

2. I recommend wrapping a try/catch around it. You wouldn't want you skill/action to bomb out because analytics failed.

3. I recommend doing the call Async vs Sync. I did not build out an async so you'd have to do that yourself, or modify the git.

4. The MetaData I've left as a Dictionary, so if you try to add duplicate keys (name) you'll get an error. I don't know if it should be or not based on VoiceLabs actual API, but it's never been a problem for me. 

        [TestMethod]
        public void Test_SendAlexa()
        {
            // NOTE Multiple runs of this unit test will add intents
            // to the same session in the VoiceLabs console.

                AnalyticsData data = new AnalyticsData(
                "Added wet. You now have 2 for the day.");

            //data.AddMetaData("resolvedQuery", "add wet");
            // Meta Data can be used for anything you wish.
            // As far as I know, VoiceLabs is using it for
            // the resolveQuery from Google Assistant,
            // but I actually put a serialized version
            // of the full request into the meta data.
            // So use it as you require.


            //https://developer.amazon.com/public/solutions/alexa/alexa-skills-kit/docs/alexa-skills-kit-interface-reference
            // Pull the request.user.userId from the JSON request from Alexa.
            // Pull the session ID from request.session.sessionId from the JSON request from Alexa.
            // Pull the Intent from the request.content 
            //      (NOTE: Depending on the request type the Intent may or may not be populated).
            //      It is recommended that if you get a request type where the Intent is not populated
            //      instead of passing the Intent, you pass the request type. For example, a LaunchRequest
            //      IE, where the user just says "open <skill>". Your code will receive a LaunchRequest. Instead of
            //      populating with the intent (which will be NULL for a LaunchRequest) you should pull the request type
            //      so it displays LaunchRequest in the voicelabs console.
            // Populate the meta data as you see fit. Whatever you put in this will show up on the VoiceLabs pages where
            //      text spoke from the user would go. I used the entire request from Alexa.
            // Pull the app id from the VoiceLabs console under the Admin section.
            AnalyticsRequest request =
                new AnalyticsRequest(
                    "amzn.12345.12334234",
                    "amznsession.a123123.123123.123",
                    "AddWet",
                    data,
                    "Enter your App ID");

            request.Send();
        }

        [TestMethod]
        public void Test_SendGoogleHome()
        {
            // NOTE Multiple runs of this unit test will add intents
            // to the same session in the VoiceLabs console.

            AnalyticsData data = new AnalyticsData(
                "Added wet. You now have 2 for the day.");

            data.AddMetaData("resolvedQuery", "add wet");
            // Meta Data can be used for anything you wish.
            // As far as I know, VoiceLabs is using it for
            // the resolveQuery from Google Assistant,
            // but I actually put a serialized version
            // of the full request into the meta data.
            // So use it as you require.

            //NOTE: I do not have the V2 specs, so someone might have to add that in later.
            //https://developers.google.com/actions/reference/v1/apiai-webhook
            // Pull the user ID from the user_id field in the web hook request. request.originalRequest.data.user.user_id.
            // Pull the session from request.sessionId
            // Pull the intent from request.metadata.intentName
            // Populate the meta data as you see fit.
            // Populate the meta data as you see fit. Whatever you put in this will show up on the VoiceLabs pages where
            //      text spoke from the user would go. I used the entire request from Google Home, but typically it's
            //      just the resolvedQuery.
            // Pull the app id from the VoiceLabs console under the Admin section.

            AnalyticsRequest request =
                new AnalyticsRequest(
                    "1232312423232",
                    "123213231",
                    "AddWet",
                    data,
                    "Enter your App ID");

            request.Send();
        }
