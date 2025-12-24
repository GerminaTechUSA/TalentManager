<template>
    <aside class="sidebar">

        <div class="app-logo">
            <RouterLink to="/">
                <div class="logo-icon">
                    <img :src="logoIcon" alt="Instituto J&F logo" class="logo-icon-img">
                </div>
            </RouterLink>
        </div>

        <nav class="sidebar-nav" ref="sidebarNav">
                <div class="nav-list">

                    <div class="nav-item-list" @click="toggleSessao('profissional')" :class="{ 'nav-item-list--active' : activeSection === 'profissional' }" >
                        <img :src="profissionalIcon" alt="Profissional" class="nav-img">
                        <span class="nav-text">Profissional</span>
                        <button class="nav-button">
                            <img :src="arrow" alt="arrow" class="nav-arrow">
                        </button>
                    </div>

                    <Transition name="expand">
                        <div class="nav-links" v-show="activeSection === 'profissional'">
                            <RouterLink to="/" class="nav-item">
                                <span class="nav-item-text">- Pessoas</span>
                            </RouterLink>
                            <RouterLink to="/" class="nav-item">
                                <span class="nav-item-text">- Softwares</span>
                            </RouterLink>
                            <RouterLink to="/" class="nav-item">
                                <span class="nav-item-text">- Módulos</span>
                            </RouterLink>
                            <RouterLink to="/" class="nav-item">
                                <span class="nav-item-text">- Companhias</span>
                            </RouterLink>
                            <RouterLink to="/" class="nav-item">
                                <span class="nav-item-text">- Área de Negócios</span>
                            </RouterLink>
                        </div>
                    </Transition>

                </div>

                <div class="nav-list">

                    <div class="nav-item-list" @click="toggleSessao('experiencias')" :class="{ 'nav-item-list--active': activeSection === 'experiencias' }">
                        <img :src="experiencesIcon" alt="Experiências" class="nav-img">
                        <span class="nav-text">Experiências</span>
                        <button class="nav-button">
                            <img :src="arrow" alt="arrow" class="nav-arrow">
                        </button>
                    </div>

                    <Transition name="expand">
                        <div class="nav-links" v-show="activeSection === 'experiencias'">
                            <RouterLink to="/" class="nav-item">
                                <span class="nav-item-text">- Experiências</span>
                            </RouterLink>
                            <RouterLink to="/" class="nav-item">
                                <span class="nav-item-text">- Experiências Pessoais</span>
                            </RouterLink>
                            <RouterLink to="/" class="nav-item">
                                <span class="nav-item-text">- Tipos de Experiência</span>
                            </RouterLink>
                        </div>
                    </Transition>

                </div>
                <div class="nav-list">

                    <div class="nav-item-list" @click="toggleSessao('outros')" :class="{ 'nav-item-list--active': activeSection === 'outros'}">
                        <img :src="outrosIcon" alt="Outros" class="nav-img">
                        <span class="nav-text">Outros</span>
                        <button class="nav-button">
                            <img :src="arrow" alt="arrow" class="nav-arrow">
                        </button>
                    </div>

                    <Transition name="expand">
                        <div class="nav-links" v-show="activeSection === 'outros'">
                            <RouterLink to="/" class="nav-item">
                                <span class="nav-item-text">- Cargo</span>
                            </RouterLink>
                            <RouterLink to="/" class="nav-item">
                                <span class="nav-item-text">- Habilidades</span>
                            </RouterLink>
                            <RouterLink to="/" class="nav-item">
                                <span class="nav-item-text">- Hobbies</span>
                            </RouterLink>
                        </div>
                    </Transition>

                </div>
        </nav>

        <div class="perfil">
            <img :src="perfilIcon" alt="Perfil" id="perfil-icon">
            <div class="perfil-text">
                <h3 class="perfil-name">Gustavo</h3>
                <span class="perfil-business">JBS Global</span>
            </div>
            <img :src="homeIcon" alt="home" class="perfil-img">
            <img :src="bellIcon" alt="bells" class="perfil-img">
        </div>

    </aside>
</template>

<script setup lang="ts">
    import { RouterLink } from 'vue-router'
    import { ref } from 'vue'

    type SectionName = 'profissional' | 'experiencias' | 'outros' | ''

    const activeSection = ref<SectionName>('')
    
    function toggleSessao(sectionName: SectionName): void {
        activeSection.value = (activeSection.value === sectionName) ? '' : sectionName
    }

    import logoIcon from '@/assets/icon/logo-InstitutoJ&F.png'
    import profissionalIcon from '@/assets/icon/profissional.png'
    import outrosIcon from '@/assets/icon/curriculo.png'
    import experiencesIcon from '@/assets/icon/experiencias.png'
    import arrow from '@/assets/icon/arrow.png'
    import perfilIcon from '@/assets/icon/perfil.png'
    import homeIcon from '@/assets/icon/home.png'
    import bellIcon from '@/assets/icon/bell.png'
</script>

<style scoped>
    * {
        color: var(--white);
    }

    .sidebar{
        display: flex;
        flex-direction: column;
        background: var(--medium-blue);
        width: 25%;
        justify-content: space-around;
        align-items: center;
    }

    .logo-icon-img{
        user-select: none;
        width: 120px;
    }

    .sidebar-nav{
        height: 50%;
        width: 100%;
        display: flex;
        flex-direction: column;
        gap: 10vh;
        align-items: center;
        justify-content: center;
    }

    .nav-list{
        width: 45%;
    }

    .nav-item-list{
        display: flex;
        width:100%;
        justify-content: space-between;
        align-items: center;
        position: relative;
        margin-bottom: 25px;
        cursor: pointer;
    }

    .nav-item-list::after{
        content: "";
        position: absolute;
        bottom: -18px;
        height: 7px;
        width: 100%;
        background: var(--white);
        border-radius: 0 10px 10px 0;
        cursor: default;
    }

    .nav-text{
        font-weight: bold;
        font-size: 18px;
        width: 60%;
    }
    
    .nav-item-text{
        font-weight: bold;
    }
    
    .nav-item{
        text-decoration: none;
    }

    .nav-links{
        display: flex;
        flex-direction: column;
    }


    .nav-img{
        width: 20px;
        user-select: none;
    }

    .nav-button{
        background: none;
        border: none;
        cursor: pointer;
        user-select: none;
    }

    .nav-arrow{
        width: 10px;
        height: 20px;
        transition: 0.2s ease;
    }

    .perfil{
        display: flex;
        align-items: center;
        width: 75%;
        justify-content: space-around;
    }

    #perfil-icon{
        width: 50px;
        height: 50px;
        border-radius: 100%;
    }

    .perfil-text{
        display: flex;
        flex-direction: column;
        width: 40%;
    }
    
    .perfil-name{
        font-weight: bold;
    }
    
    .perfil-business{
        font-size: 12px;
        font-weight: bold;
    }

    .perfil-img{
        height: 25px;
    }

    .nav-item-list--active .nav-button .nav-arrow{
        rotate: 90deg;
    }

    .expand-enter-from, .expand-leave-to { max-height: 0; opacity: 0; }
    .expand-enter-to,   .expand-leave-from { max-height: 400px; opacity: 1; }
    .expand-enter-active, .expand-leave-active {
    transition: max-height .3s ease, opacity .3s ease;
    overflow: hidden;
    }

</style>