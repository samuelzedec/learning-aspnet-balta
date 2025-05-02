<template>
  <div class="q-pa-md row justify-center">
    <div style="width: 100%; max-width: 400px">
      <div style="width: 100%;" v-for="(message, index) in messages" :key="index">
				<q-chat-message
					sent
					:name="message.name"
					:text="[message.body]"
					:stamp="message.date"
					v-if="message.name === userActual"
				/>
				<q-chat-message
					:name="message.name"
					:text="[message.body]"
					:stamp="message.date"
					v-else
				/>
			</div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { defineProps } from 'vue';
import type { Message } from "@/Interfaces/Message";

defineProps({
	messages: {
		required: true,
    type: Array as () => Message[],
	},
	userActual: {
		required: true,
		type: String
	}
});

</script>
