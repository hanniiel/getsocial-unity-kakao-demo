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

#if UNITY_ANDROID
using System;

namespace GetSocialSdk.Core
{
    internal class InviteFriendsListenerProxy : JavaInterfaceProxy
    {
        private readonly Action onInviteFriendsIntentAction;
        private readonly Action<int> onInvitedFriendsAction;

        internal InviteFriendsListenerProxy(Action onInviteFriendsIntent, Action<int> onInvitedFriends) : base("im.getsocial.sdk.core.GetSocial$InviteFriendsListener")
        {
            this.onInviteFriendsIntentAction = onInviteFriendsIntent;
            this.onInvitedFriendsAction = onInvitedFriends;
        }

        void onInviteFriendsIntent()
        {
            MainThreadExecutor.Queue(onInviteFriendsIntentAction);
        }

        void onInvitedFriends(int friendsInvited)
        {
            MainThreadExecutor.Queue(() => onInvitedFriendsAction(friendsInvited));
        }
    }
}
#endif
