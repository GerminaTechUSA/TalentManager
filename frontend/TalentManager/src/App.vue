<template>
    <div class="app-shell">
        <Sidebar />
        <main class="app-main">
            <RouterView />
        </main>
    </div>
</template>

<script setup lang="ts">
    import { RouterView } from 'vue-router'
    import Sidebar from './components/Sidebar.vue'
</script>

<style>
    body {
        margin: 0;
    }

    #app {
        height: 100vh;
    }
    
    .app-shell{
        display: flex;
        height: 100%;
        width: 100vw;
    }

    .app-main {
        width: 75%;
        background: #f5efeb;
        border-radius: 24px;
        padding: 40px 56px;
        box-shadow: 0 18px 40px rgba(0, 0, 0, 0.12);
        overflow-y: auto;
    }
</style>