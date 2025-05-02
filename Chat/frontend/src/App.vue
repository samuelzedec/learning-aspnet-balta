<template>
  <q-layout view="lHh Lpr lFf">
    <q-page-container>
      <q-input
        outlined
        placeholder="Informe seu nome"
        v-model="message.name"
        class="q-mt-sm q-pa-sm"
        dense
      />

      <chat-component
        :messages="messages"
        :user-actual="message.name"
      />

      <q-input
        outlined
        @keyup.enter="sendAsync"
        v-model="message.body"
        placeholder="Digite sua mensagem"
        class="q-mt-xl q-pa-s,"
        dense
      >
        <template v-slot:append>
          <q-icon size="sm" name="search"/>
        </template>
      </q-input>
    </q-page-container>
  </q-layout>
</template>

<script setup lang="ts">
import ChatComponent from "@/components/ChatComponent.vue";
import type { Message } from "@/Interfaces/Message.ts";
import { HubProvider } from "@/Hubs/HubProvider";
import { onMounted, ref } from "vue";

const message = ref<Message>(Object.assign({}));
const messages = ref<Message[]>([]);
const hub: HubProvider = new HubProvider();

onMounted(() => {
  hub.messageReceivedAsync((msg: Message) => {
    messages.value.push(msg);
  });
});
 
async function sendAsync(): Promise<void> {
  if (message.value.name === "" || message.value.body === "") return;
  await hub.sendMessageAsync(message.value);
  message.value.body = "";
}

</script>
