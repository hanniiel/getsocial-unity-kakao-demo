/**
 *     Copyright 2015-2016 GetSocial B.V.
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *     http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#if UNITY_IOS
using System;

namespace GetSocialSdk.Core
{
    static class OnUserGeneratedContentListenerProxy
    {
        public delegate string OnUserGeneratedContentDelegate(IntPtr actionPtr, int contentSource, string content);

        [MonoPInvokeCallback(typeof(OnUserGeneratedContentDelegate))]
        public static string OnUserGeneratedContentCallback(IntPtr actionPtr, int contentSource, string content)
        {
            if(actionPtr != IntPtr.Zero)
            {
                var action = actionPtr.Cast<OnUserGeneratedContent>();
                var contentSourceEnum = (GetSocial.ContentSource)contentSource;
                return action(contentSourceEnum, content);
            }

            return null;
        }
    }
}
#endif
