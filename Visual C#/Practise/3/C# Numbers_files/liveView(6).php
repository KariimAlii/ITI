
                        try
                        {
                            var linksArray = '  https://live.primis.tech/content/video/hls/hls.0.12.4_3.min.js  https://live.primis.tech/content/prebid/prebidVid.6.18.0_15.min.js   https://live.primis.tech/live/liveVideo.php?vpaidManager=sekindo&s=58057&ri=6C69766553746174737C736B317B54307D7B64323032322D30392D33305F32317D7B7331363930363935387D7B433132357D7B53643364334C6E523164473979615746736333526C59574E6F5A584975593239747D7B626368726F6D657D7B716465736B746F707D7B6F77696E646F77737D7B583639307D7B593233307D7B66337D7B4C31323331357DFEFE&userIpAddr=41.45.239.55&userUA=Mozilla%2F5.0+%28Windows+NT+10.0%3B+Win64%3B+x64%29+AppleWebKit%2F537.36+%28KHTML%2C+like+Gecko%29+Chrome%2F105.0.0.0+Safari%2F537.36&debugInformation=&isWePassGdpr=1&noViewableMidrollPolicy=vary&isDoublePreroll=1&autoSkipVideoSec=30&c2pWaitTime=10&sdkv=&isSinglePageFloatSupport=0&csuuid=62fd6b984776b&debugInfo=16906958_&debugPlayerSession=&pubUrlDEMO=&isAsyncDEMO=0&customPlaylistIdDEMO=&sta=16906958&showLogo=0&clkUrl=&plMult=-1&schedule=eyJwcmVfcm9sbCI6MSwibWlkX3JvbGwiOltdLCJnYXAiOiJhdXRvIn0%3D&content=plembed309bivgosmjx&secondaryContent=&x=690&y=230&pubUrl=https%3A%2F%2Fwww.tutorialsteacher.com%2Fcsharp%2Fnumbers&contentNum=1&flow_closeBtn=1&flowCloseTimeout=0&flow_closeButtonPosition=right&flow_direction=br&flow_horizontalOffset=1&flow_bottomOffset=1&impGap=1&flow_width=350&flow_height=197&videoType=flow&gdpr=0&gdprConsent=&contentFeedId=&geoLati=30.9977&geoLong=29.7432&vpTemplate=12315&flowMode=seenboth&isRealPreroll=0&playerApiId=&isApp=0&ccpa=0&ccpaConsent=&subId=www.tutorialsteacher.com'.split(' ');

                            for(var l = 0; l < linksArray.length; l++)
                            {
                                if(linksArray[l].length > 10)
                                {
                                    var sc = document.createElement('script');
                                    sc.type = 'text/javascript';
                                    sc.async = false;
                                    sc.src = linksArray[l];
                                    document.head.appendChild(sc);
                                }
                            }
                        }
                        catch(e)
                        {
                            document.write('<script type="text/javascript" src="https://live.primis.tech/content/video/hls/hls.0.12.4_3.min.js">\x3C/script><script type="text/javascript" src="https://live.primis.tech/content/prebid/prebidVid.6.18.0_15.min.js">\x3C/script><script type=' + "'" + 'text/javascript' + "'" + ' language=' + "'" + 'javascript' + "'" + ' src="https://live.primis.tech/live/liveVideo.php?vpaidManager=sekindo&s=58057&ri=6C69766553746174737C736B317B54307D7B64323032322D30392D33305F32317D7B7331363930363935387D7B433132357D7B53643364334C6E523164473979615746736333526C59574E6F5A584975593239747D7B626368726F6D657D7B716465736B746F707D7B6F77696E646F77737D7B583639307D7B593233307D7B66337D7B4C31323331357DFEFE&userIpAddr=41.45.239.55&userUA=Mozilla%2F5.0+%28Windows+NT+10.0%3B+Win64%3B+x64%29+AppleWebKit%2F537.36+%28KHTML%2C+like+Gecko%29+Chrome%2F105.0.0.0+Safari%2F537.36&debugInformation=&isWePassGdpr=1&noViewableMidrollPolicy=vary&isDoublePreroll=1&autoSkipVideoSec=30&c2pWaitTime=10&sdkv=&isSinglePageFloatSupport=0&csuuid=62fd6b984776b&debugInfo=16906958_&debugPlayerSession=&pubUrlDEMO=&isAsyncDEMO=0&customPlaylistIdDEMO=&sta=16906958&showLogo=0&clkUrl=&plMult=-1&schedule=eyJwcmVfcm9sbCI6MSwibWlkX3JvbGwiOltdLCJnYXAiOiJhdXRvIn0%3D&content=plembed309bivgosmjx&secondaryContent=&x=690&y=230&pubUrl=https%3A%2F%2Fwww.tutorialsteacher.com%2Fcsharp%2Fnumbers&contentNum=1&flow_closeBtn=1&flowCloseTimeout=0&flow_closeButtonPosition=right&flow_direction=br&flow_horizontalOffset=1&flow_bottomOffset=1&impGap=1&flow_width=350&flow_height=197&videoType=flow&gdpr=0&gdprConsent=&contentFeedId=&geoLati=30.9977&geoLong=29.7432&vpTemplate=12315&flowMode=seenboth&isRealPreroll=0&playerApiId=&isApp=0&ccpa=0&ccpaConsent=&subId=www.tutorialsteacher.com">\x3C/script>');
                        }
                        