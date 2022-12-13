import Vue from 'vue';
import Buefy from 'buefy';
import App from './App.vue';
import router from './router';
import VueApollo from 'vue-apollo';
import ApolloClient from './graphql/client';
import { setInteractionMode } from 'vee-validate';
import { extend } from 'vee-validate';
import * as rules from 'vee-validate/dist/rules';

import 'buefy/dist/buefy.css';

Vue.use(Buefy);
Vue.use(VueApollo);
Vue.config.productionTip = false;

setInteractionMode('eager');

for (const [rule, validation] of Object.entries(rules)) {
  extend(rule, {
    ...validation
  });
}
const apolloProvider = new VueApollo({
  defaultClient: ApolloClient
});

new Vue({
  router,
  apolloProvider,
  render: h => h(App)
}).$mount('#app');
