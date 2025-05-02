import {
  HubConnection,
  HubConnectionBuilder,
  LogLevel,
} from "@microsoft/signalr";
import type { Message } from "../Interfaces/Message";

export class HubProvider {
  private readonly URL: string = "http://localhost:5154/chat";
  private connection: HubConnection;

  constructor() {
    this.connection = new HubConnectionBuilder()
      .withUrl(this.URL, {
        withCredentials: false,
      })
      .configureLogging(LogLevel.Information)
      .build();
  }

  private async startAsync(): Promise<void> {
    await this.connection.start();
  }

  public async messageReceivedAsync(
    callback: (msg: Message) => void
  ): Promise<void> {
    try {
      await this.startAsync();
      this.connection.on("ReceivedMessage", callback);
    } catch (err) {
      console.error("Ocorreu um erro:", err);
    }
  }

  public async sendMessageAsync(message: Message): Promise<void> {
    try {
      await this.connection.invoke("SendMessage", message);
    } catch (err) {
      console.error("Erro ao enviar mensagem:", err);
    }
  }
}
